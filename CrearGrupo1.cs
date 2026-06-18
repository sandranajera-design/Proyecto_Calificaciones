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

            this.Load += CrearGrupo1_Load;
            this.Resize += CrearGrupo1_Resize;
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

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreGrupo.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del grupo.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreGrupo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCantidadApartados.Text))
            {
                MessageBox.Show("Debe ingresar la cantidad de apartados.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidadApartados.Focus();
                return;
            }

            int cantidadApartados;

            if (!int.TryParse(txtCantidadApartados.Text, out cantidadApartados))
            {
                MessageBox.Show("La cantidad de apartados debe ser un número.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidadApartados.Focus();
                return;
            }

            if (cantidadApartados <= 0)
            {
                MessageBox.Show("La cantidad de apartados debe ser mayor a cero.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidadApartados.Focus();
                return;
            }

            CrearGrupo2 form = new CrearGrupo2(txtNombreGrupo.Text, cantidadApartados);
            form.Show();

            this.Hide();
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

        private void panelSistema_Paint(object sender, PaintEventArgs e)
        {

        }

        // ===== MÉTODOS DE CENTRADO =====

        private void CentrarPanelSistema()
        {
            panelSistema.Left = (this.ClientSize.Width - panelSistema.Width) / 2;
            panelSistema.Top = (this.ClientSize.Height - panelSistema.Height) / 2;
        }

        private void CentrarControles()
        {
            int centroX = panelSistema.Width / 2;

            label1.Left = centroX - (label1.Width / 2);
            label1.Top = 140;

            txtNombreGrupo.Left = centroX - (txtNombreGrupo.Width / 2);
            txtNombreGrupo.Top = label1.Bottom + 40;

            label2.Left = centroX - (label2.Width / 2);
            label2.Top = txtNombreGrupo.Bottom + 50;

            txtCantidadApartados.Left = centroX - (txtCantidadApartados.Width / 2);
            txtCantidadApartados.Top = label2.Bottom + 50;

            btnSiguiente.Left = centroX - (btnSiguiente.Width / 2);
            btnSiguiente.Top = txtCantidadApartados.Bottom + 40;
        }

        private void CrearGrupo1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;

            CentrarPanelSistema();
            CentrarControles();
        }

        private void CrearGrupo1_Resize(object sender, EventArgs e)
        {
            CentrarPanelSistema();
            CentrarControles();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtNombreGrupo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}