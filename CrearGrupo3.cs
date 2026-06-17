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


namespace Proyecto_Calificaciones
{
    public partial class CrearGrupo3 : Form
    {
        public CrearGrupo3()
        {
            InitializeComponent();
        }

        private void btnGenerarTabla_Click(object sender, EventArgs e)
        {
            CrearGrupo4 form = new CrearGrupo4();
            form.Show();

            this.Hide();

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
            VerListaGrupos form = new VerListaGrupos();
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
            //abrir una ventana para seleccionar el archivo .xls y .xlsx
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "archivos de Excel|*.xlsx|Archivos de Excel97-2003|*.xls" })
            {
                //verifica que el usuario haya seleccionado un archivo
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    rutaArchivo = ofd.FileName; //guarda la ruta del archivo elegdo

                    //verifica que el archivo no este abrierto
                    try
                    {
                        //abre el archivo en modo lectura
                        using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                        {
                            //crea un lector para archivos excel
                            using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                // Convierte el archivo en tablas
                                var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                                    {
                                        UseHeaderRow = true //para tomar la primera fila como encabezado
                                    }
                                });

                                dataGridView1.DataSource = dataSet.Tables[0];

                                //encabezados de las columnas
                                dataGridView1.Columns[0].HeaderText = "N° lista";
                                dataGridView1.Columns[1].HeaderText = "ID";
                                dataGridView1.Columns[2].HeaderText = "Nombre";
                                dataGridView1.Columns[3].HeaderText = "ApellidoP";
                                dataGridView1.Columns[4].HeaderText = "ApellidoM";

                                //ajusta el tamaño de las celdas
                                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                                dataGridView1.AutoResizeColumns();

                                dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12); //funte del texto
                            }
                        }
                    }
                    catch (IOException ex) //si es achivo está abierto muestra un mensaje
                    {
                        MessageBox.Show("El archivo está en abierto.\nCiérrelo antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Pedir al usuario el nombre de la columna a eliminar
            string nombreColumna = Microsoft.VisualBasic.Interaction.InputBox(
                "Escribe el nombre de la columna que deseas eliminar:",
                "Eliminar columna",
                ""
            );

            if (!string.IsNullOrWhiteSpace(nombreColumna) && dataGridView1.Columns.Contains(nombreColumna))
            {
                dataGridView1.Columns.Remove(nombreColumna);
            }
            else
            {
                MessageBox.Show("La columna " + nombreColumna + " no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void agregarColumna_Click(object sender, EventArgs e)
        {
            string nombreColumna = Microsoft.VisualBasic.Interaction.InputBox(
                "Escribe el nombre de la nueva columna:",
                "Agregar columna",
                "NuevaColumna"
            );

            if (!string.IsNullOrWhiteSpace(nombreColumna))
            {
                // Agregar columna al DataGridView
                dataGridView1.Columns.Add(nombreColumna, nombreColumna);

                // inicializa las celdas vacías
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells[nombreColumna].Value = "";
                }
            }
        }

        private void exportar_Click(object sender, EventArgs e)
        {
            ExportarExcel(dataGridView1); //llama la función de exportar
        }

        //función de exportar
        private void ExportarExcel(DataGridView dataGridView)
        {
            if (string.IsNullOrEmpty(rutaArchivo)) //si no se seleccionó un archivo muestra un mensaje
            {
                MessageBox.Show("No hay archivo importado para exportar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;

            try
            {
                Excel.Workbook workbook = excelApp.Workbooks.Open(rutaArchivo); //abre el archivo
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1]; //obtiene la primera hoja

                //obtiene el numero dde columnas 
                int columCount = dataGridView.ColumnCount;
                for (int i = 0; i < columCount; i++)
                {
                    worksheet.Cells[1, i + 1] = dataGridView.Columns[i].HeaderText; //escribe el encabezados
                }

                //obtiene las filas
                int rowCount = dataGridView.RowCount;
                for (int i = 0; i < rowCount; i++)
                {
                    for (int j = 0; j < columCount; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value?.ToString();//escribe lo datos de las celdas
                    }
                }

                workbook.Save(); //guarda los cambios
                MessageBox.Show("Cambios guardados en: " + rutaArchivo);
            }
            catch (System.Runtime.InteropServices.COMException ex) //por si esta abierto el archivo
            {
                MessageBox.Show("El archivo está abierto en Excel. Ciérrelo antes de exportar.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally //al finalizar cierra EXCEL
            {
                excelApp.Quit();
            }
        }
    }
}
