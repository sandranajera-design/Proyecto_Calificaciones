using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.IO;

namespace Proyecto_Calificaciones
{
    public partial class ModificarAlumno2 : Form
    {
        private string rutaArchivo;
        private int filaExcel;
        public ModificarAlumno2()
        {
            InitializeComponent();
        }
        public ModificarAlumno2(string rutaArchivo, int filaExcel)
        {
            InitializeComponent();

            this.rutaArchivo = rutaArchivo;
            this.filaExcel = filaExcel;

            CargarAlumnoSeleccionado();

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
        private void CargarAlumnoSeleccionado()
        {
            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("No se encontró el archivo Excel del grupo.", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                for (int columna = 1; columna <= columnas; columna++)
                {
                    tabla.Columns.Add(hoja.Cell(1, columna).Value.ToString());
                }

                DataRow fila = tabla.NewRow();

                for (int columna = 1; columna <= columnas; columna++)
                {
                    fila[columna - 1] = hoja.Cell(filaExcel, columna).Value.ToString();
                }

                tabla.Rows.Add(fila);
            }

            dataGridView1.DataSource = tabla;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            BloquearColumnasNoEditables();
        }
        private void BloquearColumnasNoEditables()
        {
            if (dataGridView1.Columns.Count == 0)
            {
                return;
            }

            int ultimaColumna = dataGridView1.Columns.Count - 1;

            dataGridView1.Columns[ultimaColumna].ReadOnly = true;
        }
        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rutaArchivo))
            {
                MessageBox.Show("No se ha cargado ningún archivo.", "Sin archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                dataGridView1.EndEdit();

                using (var libro = new XLWorkbook(rutaArchivo))
                {
                    var hoja = libro.Worksheet("Calificaciones");
                    var hojaConfig = libro.Worksheet("Configuracion");

                    int ultimaColumna = dataGridView1.Columns.Count - 1;

                    // Guardar todos los datos editables excepto calificación final
                    for (int columnaGrid = 0; columnaGrid < dataGridView1.Columns.Count; columnaGrid++)
                    {
                        if (columnaGrid == ultimaColumna)
                        {
                            continue;
                        }

                        object valor = dataGridView1.Rows[0].Cells[columnaGrid].Value;
                        hoja.Cell(filaExcel, columnaGrid + 1).Value = valor == null ? "" : valor.ToString();
                    }

                    // Calcular promedio usando los porcentajes de la hoja Configuracion
                    decimal calificacionFinal = 0;

                    int filaPorcentaje = 5;
                    int columnaPrimerApartadoGrid = 5; // En DataGridView: índice 5 = columna F de Excel

                    while (!hojaConfig.Cell(filaPorcentaje, 1).IsEmpty())
                    {
                        decimal porcentaje = hojaConfig.Cell(filaPorcentaje, 2).GetValue<decimal>();

                        int columnaGrid = columnaPrimerApartadoGrid + (filaPorcentaje - 5);

                        decimal calificacion = 0;

                        if (columnaGrid < ultimaColumna)
                        {
                            object valorCalificacion = dataGridView1.Rows[0].Cells[columnaGrid].Value;

                            if (valorCalificacion != null && !string.IsNullOrWhiteSpace(valorCalificacion.ToString()))
                            {
                                if (!decimal.TryParse(valorCalificacion.ToString(), out calificacion))
                                {
                                    MessageBox.Show("Una de las calificaciones no es válida.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                        }

                        calificacionFinal += calificacion * (porcentaje / 100);

                        filaPorcentaje++;
                    }

                    calificacionFinal = Math.Round(calificacionFinal, 2);

                    // Guardar calificación final en Excel
                    hoja.Cell(filaExcel, ultimaColumna + 1).Value = calificacionFinal;

                    libro.Save();

                    // Mostrar calificación final actualizada en el DataGridView
                    dataGridView1.Rows[0].Cells[ultimaColumna].Value = calificacionFinal;
                }

                MessageBox.Show("Cambios guardados y promedio actualizado correctamente.", "Guardado exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ModificarAlumno1 form = new ModificarAlumno1(rutaArchivo);
                form.Show();

                this.Hide();
            }
            catch (IOException)
            {
                MessageBox.Show("No se pudo guardar porque el archivo Excel está abierto. Cierre el archivo y vuelva a intentarlo.", "Archivo en uso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar cambios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void panelSistema_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
