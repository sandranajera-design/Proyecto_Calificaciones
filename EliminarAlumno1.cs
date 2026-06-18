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
    public partial class EliminarAlumno1 : Form
    {
        private string rutaArchivo;
        public EliminarAlumno1()
        {
            InitializeComponent();
        }
        public EliminarAlumno1(string rutaArchivo)
        {
            InitializeComponent();

            this.rutaArchivo = rutaArchivo;

            label1.Text = "Seleccione el alumno que desea eliminar";

            CargarAlumnos();

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
        private void CargarAlumnos()
        {
            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("No se encontró el archivo Excel del grupo.", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable tabla = new DataTable();

            tabla.Columns.Add("FilaExcel");
            tabla.Columns.Add("N° lista");
            tabla.Columns.Add("ID");
            tabla.Columns.Add("Nombre");
            tabla.Columns.Add("ApellidoP");
            tabla.Columns.Add("ApellidoM");

            using (var libro = new XLWorkbook(rutaArchivo))
            {
                var hoja = libro.Worksheet("Calificaciones");
                var ultimaFilaUsada = hoja.LastRowUsed();

                if (ultimaFilaUsada == null)
                {
                    return;
                }

                int ultimaFila = ultimaFilaUsada.RowNumber();

                for (int fila = 2; fila <= ultimaFila; fila++)
                {
                    string nombre = hoja.Cell(fila, 3).Value.ToString();

                    if (string.IsNullOrWhiteSpace(nombre))
                    {
                        continue;
                    }

                    DataRow nuevaFila = tabla.NewRow();

                    nuevaFila["FilaExcel"] = fila.ToString();
                    nuevaFila["N° lista"] = hoja.Cell(fila, 1).Value.ToString();
                    nuevaFila["ID"] = hoja.Cell(fila, 2).Value.ToString();
                    nuevaFila["Nombre"] = hoja.Cell(fila, 3).Value.ToString();
                    nuevaFila["ApellidoP"] = hoja.Cell(fila, 4).Value.ToString();
                    nuevaFila["ApellidoM"] = hoja.Cell(fila, 5).Value.ToString();

                    tabla.Rows.Add(nuevaFila);
                }
            }

            dataGridView1.DataSource = tabla;

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dataGridView1.Columns["FilaExcel"] != null)
            {
                dataGridView1.Columns["FilaExcel"].Visible = false;
            }
        }
        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un alumno para eliminar.", "Alumno no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreAlumno = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString() + " " +
                                  dataGridView1.CurrentRow.Cells["ApellidoP"].Value.ToString() + " " +
                                  dataGridView1.CurrentRow.Cells["ApellidoM"].Value.ToString();

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de eliminar al alumno: " + nombreAlumno + "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.No)
            {
                return;
            }

            try
            {
                int filaExcel = Convert.ToInt32(dataGridView1.CurrentRow.Cells["FilaExcel"].Value);

                using (var libro = new XLWorkbook(rutaArchivo))
                {
                    var hoja = libro.Worksheet("Calificaciones");

                    hoja.Row(filaExcel).Delete();

                    ReordenarNumerosLista(hoja);

                    libro.Save();
                }

                MessageBox.Show("Alumno eliminado correctamente.", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarAlumnos();
            }
            catch (IOException)
            {
                MessageBox.Show("No se pudo eliminar porque el archivo Excel está abierto. Cierre el archivo y vuelva a intentarlo.", "Archivo en uso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar alumno: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ReordenarNumerosLista(IXLWorksheet hoja)
        {
            var ultimaFilaUsada = hoja.LastRowUsed();

            if (ultimaFilaUsada == null)
            {
                return;
            }

            int ultimaFila = ultimaFilaUsada.RowNumber();
            int numeroLista = 1;

            for (int fila = 2; fila <= ultimaFila; fila++)
            {
                string nombre = hoja.Cell(fila, 3).Value.ToString();

                if (!string.IsNullOrWhiteSpace(nombre))
                {
                    hoja.Cell(fila, 1).Value = numeroLista;
                    numeroLista++;
                }
            }
        }
        private void panelSistema_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
