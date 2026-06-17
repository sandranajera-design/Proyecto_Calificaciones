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

namespace Proyecto_Calificaciones
{
    public partial class EliminarGrupo1 : Form
    {
        private List<GrupoRegistrado> grupos = new List<GrupoRegistrado>();
        private List<Button> botonesGrupos = new List<Button>();
        public EliminarGrupo1()
        {
            InitializeComponent();
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
        private void CargarBotonesGrupos()
        {
            label2.Visible = false;
            label3.Visible = false;

            foreach (Button boton in botonesGrupos)
            {
                this.Controls.Remove(boton);
                boton.Dispose();
            }

            botonesGrupos.Clear();

            grupos = AdministradorExcel.ObtenerGruposRegistrados();

            if (grupos.Count == 0)
            {
                label2.Text = "No hay grupos registrados.";
                label2.Visible = true;
                return;
            }

            int x = 280;
            int y = 100;

            foreach (GrupoRegistrado grupo in grupos)
            {
                Button botonGrupo = new Button();

                botonGrupo.Text = grupo.NombreGrupo;
                botonGrupo.Tag = grupo;
                botonGrupo.Location = new Point(x, y);
                botonGrupo.Size = new Size(300, 40);
                botonGrupo.Click += btnGrupoDinamico_Click;

                this.Controls.Add(botonGrupo);
                botonesGrupos.Add(botonGrupo);

                y += 50;
            }
        }
        private void btnGrupoDinamico_Click(object sender, EventArgs e)
        {
            Button boton = sender as Button;

            if (boton == null)
            {
                return;
            }

            GrupoRegistrado grupo = boton.Tag as GrupoRegistrado;

            if (grupo == null)
            {
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de eliminar el grupo: " + grupo.NombreGrupo + "?\n\nEsta acción eliminará el archivo Excel del grupo.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (respuesta == DialogResult.No)
            {
                return;
            }

            try
            {
                AdministradorExcel.EliminarGrupo(grupo.NombreGrupo, grupo.RutaArchivo);

                MessageBox.Show("Grupo eliminado correctamente.", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarBotonesGrupos();
            }
            catch (IOException)
            {
                MessageBox.Show("No se pudo eliminar el grupo porque el archivo Excel está abierto. Cierre el archivo y vuelva a intentarlo.", "Archivo en uso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el grupo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EliminarGrupo1_Load(object sender, EventArgs e)
        {
            CargarBotonesGrupos();
        }
    }
}
