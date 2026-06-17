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

    public partial class CrearGrupo2 : Form
    {
        string nombreGrupo;
        int cantidadApartados;

        List<TextBox> txtNombresApartados = new List<TextBox>();
        List<TextBox> txtPorcentajesApartados = new List<TextBox>();
        public CrearGrupo2()
        {
            InitializeComponent();
        }
        public CrearGrupo2(string nombreGrupo, int cantidadApartados)
        {
            InitializeComponent();

            this.nombreGrupo = nombreGrupo;
            this.cantidadApartados = cantidadApartados;

            GenerarCamposApartados();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            List<ApartadoEvaluacion> apartados = new List<ApartadoEvaluacion>();
            decimal sumaPorcentajes = 0;

            for (int i = 0; i < cantidadApartados; i++)
            {
                if (string.IsNullOrWhiteSpace(txtNombresApartados[i].Text))
                {
                    MessageBox.Show("Debe ingresar el nombre del apartado " + (i + 1) + ".", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombresApartados[i].Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPorcentajesApartados[i].Text))
                {
                    MessageBox.Show("Debe ingresar el porcentaje del apartado " + (i + 1) + ".", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPorcentajesApartados[i].Focus();
                    return;
                }

                decimal porcentaje;
                string textoPorcentaje = txtPorcentajesApartados[i].Text.Replace("%", "").Trim();

                if (!decimal.TryParse(textoPorcentaje, out porcentaje))
                {
                    MessageBox.Show("El porcentaje del apartado " + (i + 1) + " debe ser un número.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPorcentajesApartados[i].Focus();
                    return;
                }

                if (porcentaje <= 0)
                {
                    MessageBox.Show("El porcentaje del apartado " + (i + 1) + " debe ser mayor a cero.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPorcentajesApartados[i].Focus();
                    return;
                }

                sumaPorcentajes += porcentaje;

                apartados.Add(new ApartadoEvaluacion
                {
                    Nombre = txtNombresApartados[i].Text.Trim(),
                    Porcentaje = porcentaje
                });
            }

            if (sumaPorcentajes != 100)
            {
                MessageBox.Show("La suma de los porcentajes debe ser 100%. Actualmente suma: " + sumaPorcentajes + "%", "Porcentajes incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CrearGrupo3 form = new CrearGrupo3(nombreGrupo, apartados);
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

        private void GenerarCamposApartados()
        {
            panelSistema.AutoScroll = true;

            label1.Text = "Defina los apartados de evaluación del grupo.";
            label1.Location = new Point(120, 50);
            label1.Size = new Size(700, 30);

            Label lblExplicacion = new Label();
            lblExplicacion.Text = "Ingrese el nombre de cada apartado y el porcentaje que tendrá en la calificación final. La suma de los porcentajes debe ser 100%.";
            lblExplicacion.Location = new Point(120, 90);
            lblExplicacion.Size = new Size(900, 50);
            panelSistema.Controls.Add(lblExplicacion);

            Label lblGrupo = new Label();
            lblGrupo.Text = "Grupo: " + nombreGrupo;
            lblGrupo.Location = new Point(120, 140);
            lblGrupo.Size = new Size(500, 30);
            panelSistema.Controls.Add(lblGrupo);

            Label lblNombre = new Label();
            lblNombre.Text = "Nombre del apartado";
            lblNombre.Location = new Point(220, 190);
            lblNombre.Size = new Size(250, 30);
            panelSistema.Controls.Add(lblNombre);

            Label lblPorcentaje = new Label();
            lblPorcentaje.Text = "Porcentaje";
            lblPorcentaje.Location = new Point(560, 190);
            lblPorcentaje.Size = new Size(150, 30);
            panelSistema.Controls.Add(lblPorcentaje);

            int y = 230;

            for (int i = 1; i <= cantidadApartados; i++)
            {
                Label lblNumero = new Label();
                lblNumero.Text = "Apartado " + i + ":";
                lblNumero.Location = new Point(120, y);
                lblNumero.Size = new Size(120, 30);
                panelSistema.Controls.Add(lblNumero);

                TextBox txtNombre = new TextBox();
                txtNombre.Name = "txtNombreApartado" + i;
                txtNombre.Location = new Point(250, y);
                txtNombre.Size = new Size(250, 31);
                panelSistema.Controls.Add(txtNombre);

                TextBox txtPorcentaje = new TextBox();
                txtPorcentaje.Name = "txtPorcentajeApartado" + i;
                txtPorcentaje.Location = new Point(560, y);
                txtPorcentaje.Size = new Size(100, 31);
                panelSistema.Controls.Add(txtPorcentaje);

                Label lblSigno = new Label();
                lblSigno.Text = "%";
                lblSigno.Location = new Point(670, y + 5);
                lblSigno.Size = new Size(30, 30);
                panelSistema.Controls.Add(lblSigno);

                txtNombresApartados.Add(txtNombre);
                txtPorcentajesApartados.Add(txtPorcentaje);

                y += 55;
            }

            btnGuardar.Location = new Point(390, y + 30);
        }

        private void panelSistema_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
