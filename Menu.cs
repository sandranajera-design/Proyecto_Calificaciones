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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        /* Abre el formulario crear grupo 1
         */
        private void btnCrearNuevoGrupo_Click(object sender, EventArgs e)
        {
            CrearGrupo1 form = new CrearGrupo1();
            form.Show();

            this.Hide();
        }

        /* salir del programa con message box para confirmar
         */
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

        private void Menu_Load(object sender, EventArgs e)
        {
            CentrarControles();
        }

        private void CentrarControles()
        {
            // Calcula el centro del formulario
            int centroX = this.ClientSize.Width / 2;
            int centroY = this.ClientSize.Height / 2;

            // Definimos un bloque mínimo para que no se vea pequeño
            int anchoBloque = Math.Max(this.ClientSize.Width / 2, 800);
            int altoBloque = Math.Max(this.ClientSize.Height / 2, 500);

            int inicioX = centroX - (anchoBloque / 2);
            int inicioY = centroY - (altoBloque / 2);

            // Centramos la etiqueta principal
            label2.Left = inicioX + (anchoBloque / 2) - (label1.Width / 2)-10;
            label2.Top = inicioY-70;
            label1.Left = inicioX + (anchoBloque / 2) - (label1.Width / 2);
            label1.Top = inicioY + 20;
            

            // Centramos los botones en columna, con espacio entre ellos
            btnCrearNuevoGrupo.Left = inicioX + (anchoBloque / 2) - (btnCrearNuevoGrupo.Width / 2);
            btnCrearNuevoGrupo.Top = label1.Bottom + 25;

            btnVerListaGrupos.Left = inicioX + (anchoBloque / 2) - (btnVerListaGrupos.Width / 2);
            btnVerListaGrupos.Top = btnCrearNuevoGrupo.Bottom + 15;

            btnEliminarGrupo.Left = inicioX + (anchoBloque / 2) - (btnEliminarGrupo.Width / 2);
            btnEliminarGrupo.Top = btnVerListaGrupos.Bottom + 15;

            btnSalir.Left = inicioX + (anchoBloque / 2) - (btnSalir.Width / 2);
            btnSalir.Top = btnEliminarGrupo.Bottom + 15;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
