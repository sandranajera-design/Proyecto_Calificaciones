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
    public partial class CrearGrupo1 : Form
    {
        bool menuAbierto = true;
        public CrearGrupo1()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (menuAbierto)
            {
                panelMenu.Width = 40;
                menuAbierto = false;
            }
            else
            {
                panelMenu.Width = 200;
                menuAbierto = true;
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
            DialogResult respuesta = MessageBox.Show( "¿Desea salir del programa?","Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
