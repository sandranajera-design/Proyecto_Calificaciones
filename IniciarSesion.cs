using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Proyecto_Calificaciones
{
    public partial class IniciarSesion : Form
    {
        public IniciarSesion()
        {
            InitializeComponent();

            // Centrar el formulario al abrir
            this.StartPosition = FormStartPosition.CenterScreen;

            // Abrir maximizado
            this.WindowState = FormWindowState.Maximized;

            // Asociar el evento Resize para mantener el panel centrado
            this.Resize += IniciarSesion_Resize;
        }

        /* Conexión con la base de datos */
        class Conexion
        {
            public static MySqlConnection conectar()
            {
                MySqlConnection con = new MySqlConnection(
                    "Server=localhost;Database=sistema_calificaciones;Uid=root;Pwd=;"
                );

                con.Open();
                return con;
            }
        }

        /* Verifica usuario y contraseña */
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = Conexion.conectar();

                string consulta = "SELECT * FROM Usuarios WHERE usuario=@usuario AND contrasena=@contrasena";
                MySqlCommand cmd = new MySqlCommand(consulta, con);

                cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                cmd.Parameters.AddWithValue("@contrasena", txtContrasena.Text);

                MySqlDataReader lector = cmd.ExecuteReader();

                if (lector.Read())
                {
                    Menu form = new Menu();
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        /* Ir al formulario de registro */
        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Registrarse form = new Registrarse();
            form.Show();
            this.Hide();
        }

        private void IniciarSesion_Load(object sender, EventArgs e)
        {
            txtContrasena.UseSystemPasswordChar = true;

            // Centrar el panel al cargar
            CentrarControles();
        }

        /* Método para centrar el panel */
        private void CentrarControles()
        {
            // Define un bloque mínimo (para que no se vea pequeño)
            int anchoBloque = Math.Max(this.ClientSize.Width / 2, 800);   // mínimo 600 px
            int altoBloque = Math.Max(this.ClientSize.Height / 2, 400);   // mínimo 400 px

            // Calcula el centro del formulario
            int centroX = this.ClientSize.Width / 2;
            int centroY = this.ClientSize.Height / 2;

            // Punto de inicio del bloque
            int inicioX = centroX - (anchoBloque / 2);
            int inicioY = centroY - (altoBloque / 2);

            // Posiciona los controles dentro del bloque con márgenes amplios
            label1.Left = inicioX + (anchoBloque / 2) - (label1.Width / 2);
            label1.Top = inicioY + 20;

            label2.Left = inicioX + 280;
            label2.Top = label1.Bottom + 50;

            txtUsuario.Left = label2.Right + 60;
            txtUsuario.Top = label2.Top;

            label3.Left = label2.Left;
            label3.Top = txtUsuario.Bottom + 40;

            txtContrasena.Left = label3.Right + 20;
            txtContrasena.Top = label3.Top;

            btnIniciarSesion.Left = inicioX + (anchoBloque / 2) - (btnIniciarSesion.Width / 2);
            btnIniciarSesion.Top = txtContrasena.Bottom + 60;

            label4.Left = inicioX + (anchoBloque / 2) - (label4.Width / 2);
            label4.Top = btnIniciarSesion.Bottom + 40;

            btnRegistrarse.Left = inicioX + (anchoBloque / 2) - (btnRegistrarse.Width / 2);
            btnRegistrarse.Top = label4.Bottom + 20;
        }




        /* Mantener centrado al redimensionar */
        private void IniciarSesion_Resize(object sender, EventArgs e)
        {
            CentrarControles();
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }
    }
}

