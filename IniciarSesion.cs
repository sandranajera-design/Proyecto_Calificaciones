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
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            //Si se hicieron cambis, si funciona Git
            //un Elefante se columpiaba sore la tela de una araña
            // Como veia que resistia fueron a llamar a otro elefante
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = Conexion.conectar();

                string consulta = "SELECT * FROM Usuarios WHERE usuario=@usuario AND password=@contrasena";

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
    }
}
