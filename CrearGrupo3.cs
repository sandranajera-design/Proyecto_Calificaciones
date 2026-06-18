using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using ExcelDataReader;
using ClosedXML.Excel;
using System.IO;


namespace Proyecto_Calificaciones
{
    public partial class CrearGrupo3 : Form
    {
        private string nombreGrupo;
        private List<ApartadoEvaluacion> apartados;
        private List<AlumnoExcel> alumnos = new List<AlumnoExcel>();

        public CrearGrupo3()
        {
            InitializeComponent();
        }
        public CrearGrupo3(string nombreGrupo, List<ApartadoEvaluacion> apartados)
        {
            InitializeComponent();

            this.nombreGrupo = nombreGrupo;
            this.apartados = apartados;
        }

        private void btnGenerarTabla_Click(object sender, EventArgs e)
        {
            if (alumnos.Count == 0)
            {
                DialogResult respuesta = MessageBox.Show(
                    "No se han importado alumnos. ¿Desea generar la tabla sin alumnos?",
                    "Sin alumnos",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (respuesta == DialogResult.No)
                {
                    return;
                }
            }

            try
            {
                string rutaArchivo = AdministradorExcel.CrearArchivoGrupo(nombreGrupo, apartados, alumnos);

                MessageBox.Show("Archivo Excel creado correctamente:\n" + rutaArchivo, "Excel generado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                

                CapturarCalificaciones2 form = new CapturarCalificaciones2(rutaArchivo);
                form.Show();

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el archivo Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCrearNuevoGrupo_Click(object sender, EventArgs e)
        {
            CrearGrupo1 form = new CrearGrupo1();
            form.Show();

            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea salir del programa?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnVerListaGrupos_Click(object sender, EventArgs e)
        {
            VerListaGrupos2 form = new VerListaGrupos2();
            form.Show();

            this.Hide();
        }

        private void btnEliminarGrupo_Click(object sender, EventArgs e)
        {
            EliminarGrupo1 form = new EliminarGrupo1();
            form.Show();

            this.Hide();
        }

        private string rutaArchivo; //guarda la ruta para despues exportar los cambios a ella

        // importar archivo
        private void btnImportarAlumnos_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Title = "Seleccionar archivo de alumnos";
            dialogo.Filter = "Archivos de Excel (*.xlsx)|*.xlsx";

            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    alumnos.Clear();

                    using (var libro = new XLWorkbook(dialogo.FileName))
                    {
                        var hoja = libro.Worksheet(1);
                        var ultimaFila = hoja.LastRowUsed().RowNumber();

                        for (int fila = 2; fila <= ultimaFila; fila++)
                        {
                            string nombre = hoja.Cell(fila, 3).Value.ToString();

                            if (string.IsNullOrWhiteSpace(nombre))
                            {
                                continue;
                            }

                            int numeroLista = 0;
                            int.TryParse(hoja.Cell(fila, 1).Value.ToString(), out numeroLista);

                            AlumnoExcel alumno = new AlumnoExcel();

                            alumno.NumeroLista = numeroLista;
                            alumno.ID = hoja.Cell(fila, 2).Value.ToString();
                            alumno.Nombre = hoja.Cell(fila, 3).Value.ToString();
                            alumno.ApellidoP = hoja.Cell(fila, 4).Value.ToString();
                            alumno.ApellidoM = hoja.Cell(fila, 5).Value.ToString();

                            alumnos.Add(alumno);
                        }
                    }

                    MostrarAlumnosEnTabla();

                    MessageBox.Show("Alumnos importados correctamente.", "Importación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al importar alumnos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

     
        private void MostrarAlumnosEnTabla()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = alumnos;
        }
        private void btnMostrarAlumnos_Click(object sender, EventArgs e)
        {
            MostrarAlumnosEnTabla();
        }

        private void panelSistema_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
