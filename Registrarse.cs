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
    }
}
