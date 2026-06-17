using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ClosedXML.Excel;

namespace Proyecto_Calificaciones
{
    public partial class CapturarCalificaciones2 : Form
    {
        private string rutaArchivo;
        public CapturarCalificaciones2()
        {
            InitializeComponent();
        }
        public CapturarCalificaciones2(string rutaArchivo)
        {
            InitializeComponent();

            this.rutaArchivo = rutaArchivo;

            CargarExcelEnTabla();

            btnCalcularPromedio.Click += btnCalcularPromedio_Click;
            btnGuardarCambios.Click += btnGuardarCambios_Click;
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
        private void CargarExcelEnTabla()
        {
            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("No se encontró el archivo Excel.", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable tabla = new DataTable();

            using (var libro = new XLWorkbook(rutaArchivo))
            {
                var hoja = libro.Worksheet("Calificaciones");
                var rango = hoja.RangeUsed();

                if (rango == null)
                {
                    return;
                }

                int columnas = rango.ColumnCount();
                int filas = rango.RowCount();

                for (int columna = 1; columna <= columnas; columna++)
                {
                    tabla.Columns.Add(hoja.Cell(1, columna).Value.ToString());
                }

                for (int fila = 2; fila <= filas; fila++)
                {
                    DataRow nuevaFila = tabla.NewRow();

                    for (int columna = 1; columna <= columnas; columna++)
                    {
                        nuevaFila[columna - 1] = hoja.Cell(fila, columna).Value.ToString();
                    }

                    tabla.Rows.Add(nuevaFila);
                }
            }

            dataGridView1.DataSource = tabla;

            BloquearColumnasFijas();
        }
        private void BloquearColumnasFijas()
        {
            if (dataGridView1.Columns.Count == 0)
            {
                return;
            }

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].ReadOnly = false;
            }

            dataGridView1.Columns[0].ReadOnly = true; // N° lista
            dataGridView1.Columns[1].ReadOnly = true; // ID
            dataGridView1.Columns[2].ReadOnly = true; // Nombre
            dataGridView1.Columns[3].ReadOnly = true; // ApellidoP
            dataGridView1.Columns[4].ReadOnly = true; // ApellidoM

            int ultimaColumna = dataGridView1.Columns.Count - 1;
            dataGridView1.Columns[ultimaColumna].ReadOnly = true; // Calificación final
        }
        private void btnCalcularPromedio_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rutaArchivo))
            {
                MessageBox.Show("No se ha cargado ningún archivo de Excel.", "Sin archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                List<decimal> porcentajes = new List<decimal>();

                using (var libro = new XLWorkbook(rutaArchivo))
                {
                    var hojaConfig = libro.Worksheet("Configuracion");

                    int fila = 5;

                    while (!hojaConfig.Cell(fila, 1).IsEmpty())
                    {
                        decimal porcentaje = hojaConfig.Cell(fila, 2).GetValue<decimal>();
                        porcentajes.Add(porcentaje);
                        fila++;
                    }
                }

                int primeraColumnaApartado = 5;
                int columnaFinal = dataGridView1.Columns.Count - 1;

                foreach (DataGridViewRow filaGrid in dataGridView1.Rows)
                {
                    if (filaGrid.IsNewRow)
                    {
                        continue;
                    }

                    decimal calificacionFinal = 0;

                    for (int i = 0; i < porcentajes.Count; i++)
                    {
                        int columnaActual = primeraColumnaApartado + i;

                        decimal calificacion = 0;

                        if (filaGrid.Cells[columnaActual].Value != null)
                        {
                            decimal.TryParse(filaGrid.Cells[columnaActual].Value.ToString(), out calificacion);
                        }

                        calificacionFinal += calificacion * (porcentajes[i] / 100);
                    }

                    filaGrid.Cells[columnaFinal].Value = Math.Round(calificacionFinal, 2);
                }

                MessageBox.Show("Promedios calculados correctamente.", "Cálculo terminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular promedios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rutaArchivo))
            {
                MessageBox.Show("No se ha cargado ningún archivo de Excel.", "Sin archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var libro = new XLWorkbook(rutaArchivo))
                {
                    var hoja = libro.Worksheet("Calificaciones");

                    for (int filaGrid = 0; filaGrid < dataGridView1.Rows.Count; filaGrid++)
                    {
                        if (dataGridView1.Rows[filaGrid].IsNewRow)
                        {
                            continue;
                        }

                        int filaExcel = filaGrid + 2;

                        for (int columnaGrid = 0; columnaGrid < dataGridView1.Columns.Count; columnaGrid++)
                        {
                            int columnaExcel = columnaGrid + 1;

                            object valor = dataGridView1.Rows[filaGrid].Cells[columnaGrid].Value;

                            hoja.Cell(filaExcel, columnaExcel).Value = valor == null ? "" : valor.ToString();
                        }
                    }

                    libro.Save();
                }

                MessageBox.Show("Cambios guardados correctamente en el archivo Excel.", "Guardado exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException)
            {
                MessageBox.Show("No se pudo guardar porque el archivo Excel está abierto. Cierra el archivo y vuelve a intentarlo.", "Archivo en uso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar cambios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Title = "Exportar archivo Excel";
            guardar.Filter = "Archivo de Excel (*.xlsx)|*.xlsx";
            guardar.FileName = "Calificaciones.xlsx";

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dataGridView1.EndEdit();

                    using (var libro = new XLWorkbook())
                    {
                        var hoja = libro.Worksheets.Add("Calificaciones");

                        for (int columna = 0; columna < dataGridView1.Columns.Count; columna++)
                        {
                            hoja.Cell(1, columna + 1).Value = dataGridView1.Columns[columna].HeaderText;
                            hoja.Cell(1, columna + 1).Style.Font.Bold = true;
                        }

                        int filaExcel = 2;

                        foreach (DataGridViewRow fila in dataGridView1.Rows)
                        {
                            if (fila.IsNewRow)
                            {
                                continue;
                            }

                            for (int columna = 0; columna < dataGridView1.Columns.Count; columna++)
                            {
                                object valor = fila.Cells[columna].Value;
                                hoja.Cell(filaExcel, columna + 1).Value = valor == null ? "" : valor.ToString();
                            }

                            filaExcel++;
                        }

                        hoja.Columns().AdjustToContents();

                        libro.SaveAs(guardar.FileName);
                    }

                    MessageBox.Show("Archivo exportado correctamente.", "Exportación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void panelSistema_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
