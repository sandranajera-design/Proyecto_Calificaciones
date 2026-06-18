using MySql.Data.MySqlClient;
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
    public partial class Registrarse : Form
    {
        public Registrarse()
        {
            InitializeComponent();
        }

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

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = Conexion.conectar();

                string insertar = "INSERT INTO Usuarios(usuario, contrasena) VALUES(@usuario, @contrasena)";

                MySqlCommand cmd = new MySqlCommand(insertar, con);

                cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                cmd.Parameters.AddWithValue("@contrasena", txtContrasena.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Usuario registrado correctamente");

                IniciarSesion form = new IniciarSesion();
                form.Show();

                this.Hide();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            IniciarSesion form = new IniciarSesion();
            form.Show();

            this.Hide();
        }

        private void Registrarse_Load(object sender, EventArgs e)
        {
            txtContrasena.UseSystemPasswordChar = true;

            // Centrar el panel al cargar
            CentrarControles();
        }

        /* Método para centrar el panel */
        private void CentrarControles()
        {
            // Define un bloque mínimo (para que no se vea pequeño)
            int anchoBloque = Math.Max(this.ClientSize.Width / 2, 800);   
            int altoBloque = Math.Max(this.ClientSize.Height / 2, 400);   

            // Calcula el centro del formulario
            int centroX = this.ClientSize.Width / 2;
            int centroY = this.ClientSize.Height / 2;

            // Punto de inicio del bloque
            int inicioX = centroX - (anchoBloque / 2);
            int inicioY = centroY - (altoBloque / 2);

            
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
            btnIniciarSesion.Top = btnRegistrarse.Bottom + 280;

            btnRegistrarse.Left = inicioX + (anchoBloque / 2) - (btnRegistrarse.Width / 2);
            btnRegistrarse.Top = txtContrasena.Bottom + 60;
        }




       
        private void IniciarSesion_Resize(object sender, EventArgs e)
        {
            CentrarControles();
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }
    }
}

