using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Calificaciones
{
    public partial class VerListaGrupos2 : Form
    {
        private List<GrupoRegistrado> grupos = new List<GrupoRegistrado>();
        public VerListaGrupos2()
        {
            InitializeComponent();
            CargarGrupos();
        }

        private void VerListaGrupos2_Load(object sender, EventArgs e)
        {

        }
        private void CargarGrupos()
        {
            grupos = AdministradorExcel.ObtenerGruposRegistrados();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = grupos;

            if (dataGridView1.Columns["RutaArchivo"] != null)
            {
                dataGridView1.Columns["RutaArchivo"].Visible = false;
            }
        }
        private void btnSeleccionarGrupo_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un grupo.", "Grupo no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string rutaArchivo = dataGridView1.CurrentRow.Cells["RutaArchivo"].Value.ToString();

            VerListaGrupos form = new VerListaGrupos(rutaArchivo);
            form.Show();

            this.Hide();
        }
    }
}
