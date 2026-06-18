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

            this.Resize += VerListaGrupos_Resize;
        }

        public VerListaGrupos(string rutaArchivo)
        {
            InitializeComponent();

            this.rutaArchivo = rutaArchivo;

            this.Resize += VerListaGrupos_Resize;
        }


        private void btnCrearNuevoGrupo_Click(object sender, EventArgs e)
        {
            CrearGrupo1 form = new CrearGrupo1();
            form.Show();

            this.Hide();
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Desea salir del programa?",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

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



        private void CentrarControles()
        {
            int centroX = panelSistema.Width / 2;

            int espacio = 15;


            // Título dentro del panel
            label1.Left = centroX - (label1.Width / 2);
            label1.Top = 140;



            // Botones SOLO del panelSistema

            btnEliminarAlumno.Left =
                centroX - (btnEliminarAlumno.Width / 2);

            btnEliminarAlumno.Top =
                label1.Bottom + 30;



            btnModificarAlumno.Left =
                centroX - (btnModificarAlumno.Width / 2);

            btnModificarAlumno.Top =
                btnEliminarAlumno.Bottom + espacio;



            btnCapturarCalificaciones.Left =
                centroX - (btnCapturarCalificaciones.Width / 2);

            btnCapturarCalificaciones.Top =
                btnModificarAlumno.Bottom + espacio;
        }





        private void VerListaGrupos_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            CentrarControles();
        }



        private void VerListaGrupos_Resize(object sender, EventArgs e)
        {
            CentrarControles();
        }



        private void panelSistema_Paint(object sender, PaintEventArgs e)
        {

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}