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

        /*Conexión con la base de datos
         */
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

        /* llama a la conexión de la base de datos y verifica que el usuario y la contraseña existan en la bd, 
         * si existen muestra el menú
         */
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

        /*lleva al formulario registrarse
         */

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Registrarse form = new Registrarse();
            form.Show();

            this.Hide();
        }

        private void IniciarSesion_Load(object sender, EventArgs e)
        {
            txtContrasena.UseSystemPasswordChar = true;
        }
    }
}
