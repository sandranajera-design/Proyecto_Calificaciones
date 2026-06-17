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
    public partial class VerListaGrupos : Form
    {
        private string rutaArchivo;
        public VerListaGrupos()
        {
            InitializeComponent();
        }
        public VerListaGrupos(string rutaArchivo)
        {
            InitializeComponent();

            this.rutaArchivo = rutaArchivo;
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

        private void btnEliminarAlumno_Click(object sender, EventArgs e)
        {
            EliminarAlumno1 form = new EliminarAlumno1(rutaArchivo);
            form.Show();

            this.Hide();
        }

        private void btnModificarAlumno_Click(object sender, EventArgs e)
        {
            ModificarAlumno1 form = new ModificarAlumno1(rutaArchivo);
            form.Show();

            this.Hide();
        }

        private void btnCapturarCalificaciones_Click(object sender, EventArgs e)
        {
            CapturarCalificaciones2 form = new CapturarCalificaciones2(rutaArchivo);
            form.Show();

            this.Hide();
        }

        private void panelSistema_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
