using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace Proyecto_Calificaciones
{
    public class ApartadoEvaluacion
    {
        public string Nombre { get; set; }
        public decimal Porcentaje { get; set; }
    }

    public class AlumnoExcel
    {
        public int NumeroLista { get; set; }
        public string ID { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
    }
    public class GrupoRegistrado
    {
        public string NombreGrupo { get; set; }
        public string RutaArchivo { get; set; }
        public string FechaCreacion { get; set; }
    }
   
    public static class AdministradorExcel
    {
        private static string carpetaSistema = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "SistemaCalificaciones"
        );

        private static string carpetaGrupos = Path.Combine(carpetaSistema, "Grupos");

        private static string archivoIndiceGrupos = Path.Combine(carpetaSistema, "Grupos.xlsx");

        public static void InicializarSistemaExcel()
        {
            if (!Directory.Exists(carpetaSistema))
            {
                Directory.CreateDirectory(carpetaSistema);
            }

            if (!Directory.Exists(carpetaGrupos))
            {
                Directory.CreateDirectory(carpetaGrupos);
            }

            if (!File.Exists(archivoIndiceGrupos))
            {
                using (var libro = new XLWorkbook())
                {
                    var hoja = libro.Worksheets.Add("Grupos");

                    hoja.Cell(1, 1).Value = "Nombre del grupo";
                    hoja.Cell(1, 2).Value = "Ruta del archivo";
                    hoja.Cell(1, 3).Value = "Fecha de creación";

                    hoja.Range("A1:C1").Style.Font.Bold = true;
                    hoja.Columns().AdjustToContents();

                    libro.SaveAs(archivoIndiceGrupos);
                }
            }
        }

        public static string CrearArchivoGrupo(string nombreGrupo, List<ApartadoEvaluacion> apartados, List<AlumnoExcel> alumnos)
        {
            InicializarSistemaExcel();

            if (string.IsNullOrWhiteSpace(nombreGrupo))
            {
                throw new Exception("El nombre del grupo no puede estar vacío.");
            }

            if (apartados == null || apartados.Count == 0)
            {
                throw new Exception("Debe existir al menos un apartado de evaluación.");
            }

            string nombreLimpio = LimpiarNombreArchivo(nombreGrupo);
            string carpetaDelGrupo = Path.Combine(carpetaGrupos, nombreLimpio);

            if (!Directory.Exists(carpetaDelGrupo))
            {
                Directory.CreateDirectory(carpetaDelGrupo);
            }

            string rutaArchivoGrupo = Path.Combine(carpetaDelGrupo, nombreLimpio + ".xlsx");

            if (File.Exists(rutaArchivoGrupo))
            {
                throw new Exception("Ya existe un archivo de Excel para este grupo.");
            }

            using (var libro = new XLWorkbook())
            {
                CrearHojaCalificaciones(libro, apartados, alumnos);
                CrearHojaConfiguracion(libro, nombreGrupo, apartados);

                libro.SaveAs(rutaArchivoGrupo);
            }

            RegistrarGrupoEnIndice(nombreGrupo, rutaArchivoGrupo);

            return rutaArchivoGrupo;
        }

        private static void CrearHojaCalificaciones(XLWorkbook libro, List<ApartadoEvaluacion> apartados, List<AlumnoExcel> alumnos)
        {
            var hoja = libro.Worksheets.Add("Calificaciones");

            hoja.Cell(1, 1).Value = "N° lista";
            hoja.Cell(1, 2).Value = "ID";
            hoja.Cell(1, 3).Value = "Nombre";
            hoja.Cell(1, 4).Value = "ApellidoP";
            hoja.Cell(1, 5).Value = "ApellidoM";

            int columna = 6;

            foreach (ApartadoEvaluacion apartado in apartados)
            {
                hoja.Cell(1, columna).Value = apartado.Nombre;
                columna++;
            }

            int columnaFinal = columna;
            hoja.Cell(1, columnaFinal).Value = "Calificación final";

            hoja.Range(1, 1, 1, columnaFinal).Style.Font.Bold = true;
            hoja.Range(1, 1, 1, columnaFinal).Style.Fill.BackgroundColor = XLColor.LightGray;
            hoja.Range(1, 1, 1, columnaFinal).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            int totalFilas;

            if (alumnos != null && alumnos.Count > 0)
            {
                totalFilas = alumnos.Count;
            }
            else
            {
                totalFilas = 40;
            }

            int filaInicio = 2;
            int filaFin = filaInicio + totalFilas - 1;

            for (int i = 0; i < totalFilas; i++)
            {
                int fila = filaInicio + i;

                if (alumnos != null && alumnos.Count > 0)
                {
                    AlumnoExcel alumno = alumnos[i];

                    hoja.Cell(fila, 1).Value = alumno.NumeroLista > 0 ? alumno.NumeroLista : i;
                    hoja.Cell(fila, 2).Value = alumno.ID;
                    hoja.Cell(fila, 3).Value = alumno.Nombre;
                    hoja.Cell(fila, 4).Value = alumno.ApellidoP;
                    hoja.Cell(fila, 5).Value = alumno.ApellidoM;
                }
                else
                {
                    hoja.Cell(fila, 1).Value = i + 1;
                }

                string columnaInicioApartados = XLHelper.GetColumnLetterFromNumber(6);
                string columnaFinApartados = XLHelper.GetColumnLetterFromNumber(columnaFinal - 1);

                int filaInicioPorcentajes = 5;
                int filaFinPorcentajes = filaInicioPorcentajes + apartados.Count - 1;

                hoja.Cell(fila, columnaFinal).FormulaA1 =
                    "IF(COUNTA(" + columnaInicioApartados + fila + ":" + columnaFinApartados + fila + ")=0,\"\",SUMPRODUCT(" +
                    columnaInicioApartados + fila + ":" + columnaFinApartados + fila +
                    ",Configuracion!$B$" + filaInicioPorcentajes + ":$B$" + filaFinPorcentajes + ")/100)";
            }

            hoja.Range(filaInicio, 6, filaFin, columnaFinal - 1).Style.NumberFormat.Format = "0.00";
            hoja.Range(filaInicio, columnaFinal, filaFin, columnaFinal).Style.NumberFormat.Format = "0.00";

            hoja.Range(1, 1, filaFin, columnaFinal).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            hoja.Range(1, 1, filaFin, columnaFinal).Style.Border.InsideBorder = XLBorderStyleValues.Thin;

            hoja.Columns().AdjustToContents();
            hoja.SheetView.FreezeRows(1);
        }

        private static void CrearHojaConfiguracion(XLWorkbook libro, string nombreGrupo, List<ApartadoEvaluacion> apartados)
        {
            var hoja = libro.Worksheets.Add("Configuracion");

            hoja.Cell(1, 1).Value = "Nombre del grupo";
            hoja.Cell(1, 2).Value = nombreGrupo;

            hoja.Cell(2, 1).Value = "Fecha de creación";
            hoja.Cell(2, 2).Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            hoja.Cell(4, 1).Value = "Apartado";
            hoja.Cell(4, 2).Value = "Porcentaje";

            hoja.Range("A4:B4").Style.Font.Bold = true;

            int fila = 5;

            foreach (ApartadoEvaluacion apartado in apartados)
            {
                hoja.Cell(fila, 1).Value = apartado.Nombre;
                hoja.Cell(fila, 2).Value = apartado.Porcentaje;
                fila++;
            }

            hoja.Columns().AdjustToContents();

            hoja.Visibility = XLWorksheetVisibility.Hidden;
        }

        private static void RegistrarGrupoEnIndice(string nombreGrupo, string rutaArchivoGrupo)
        {
            using (var libro = new XLWorkbook(archivoIndiceGrupos))
            {
                var hoja = libro.Worksheet("Grupos");

                int fila = hoja.LastRowUsed().RowNumber() + 1;

                hoja.Cell(fila, 1).Value = nombreGrupo;
                hoja.Cell(fila, 2).Value = rutaArchivoGrupo;
                hoja.Cell(fila, 3).Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

                hoja.Columns().AdjustToContents();

                libro.Save();
            }
        }

        public static void AbrirArchivoExcel(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("No se encontró el archivo Excel.", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = rutaArchivo,
                UseShellExecute = true
            });
        }

        private static string LimpiarNombreArchivo(string nombre)
        {
            foreach (char caracter in Path.GetInvalidFileNameChars())
            {
                nombre = nombre.Replace(caracter, '_');
            }

            return nombre.Trim().Replace(" ", "_");
        }
        public static void EliminarGrupo(string nombreGrupo, string rutaArchivo)
        {
            InicializarSistemaExcel();

            using (var libro = new XLWorkbook(archivoIndiceGrupos))
            {
                var hoja = libro.Worksheet("Grupos");
                var ultimaFilaUsada = hoja.LastRowUsed();

                if (ultimaFilaUsada != null)
                {
                    int ultimaFila = ultimaFilaUsada.RowNumber();

                    for (int fila = 2; fila <= ultimaFila; fila++)
                    {
                        string nombreEnExcel = hoja.Cell(fila, 1).Value.ToString();
                        string rutaEnExcel = hoja.Cell(fila, 2).Value.ToString();

                        if (nombreEnExcel == nombreGrupo && rutaEnExcel == rutaArchivo)
                        {
                            hoja.Row(fila).Delete();
                            break;
                        }
                    }
                }

                libro.Save();
            }

            string carpetaGrupo = Path.GetDirectoryName(rutaArchivo);

            if (!string.IsNullOrWhiteSpace(carpetaGrupo) &&
                carpetaGrupo.StartsWith(carpetaGrupos, StringComparison.OrdinalIgnoreCase) &&
                Directory.Exists(carpetaGrupo))
            {
                Directory.Delete(carpetaGrupo, true);
            }
            else if (File.Exists(rutaArchivo))
            {
                File.Delete(rutaArchivo);
            }
        }
        public static List<GrupoRegistrado> ObtenerGruposRegistrados()
        {
            InicializarSistemaExcel();

            List<GrupoRegistrado> grupos = new List<GrupoRegistrado>();

            using (var libro = new XLWorkbook(archivoIndiceGrupos))
            {
                var hoja = libro.Worksheet("Grupos");
                var ultimaFilaUsada = hoja.LastRowUsed();

                if (ultimaFilaUsada == null)
                {
                    return grupos;
                }

                int ultimaFila = ultimaFilaUsada.RowNumber();

                for (int fila = 2; fila <= ultimaFila; fila++)
                {
                    string nombreGrupo = hoja.Cell(fila, 1).Value.ToString();
                    string rutaArchivo = hoja.Cell(fila, 2).Value.ToString();
                    string fechaCreacion = hoja.Cell(fila, 3).Value.ToString();

                    if (string.IsNullOrWhiteSpace(nombreGrupo) || string.IsNullOrWhiteSpace(rutaArchivo))
                    {
                        continue;
                    }

                    grupos.Add(new GrupoRegistrado
                    {
                        NombreGrupo = nombreGrupo,
                        RutaArchivo = rutaArchivo,
                        FechaCreacion = fechaCreacion
                    });
                }
            }

            return grupos;
        }
    }
}