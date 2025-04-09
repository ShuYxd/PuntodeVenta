using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntodeVenta
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();

            if (usuario == "" || contraseña == "")
            {
                ERROR.Text = "Por favor completa todos los campos.";
                ERROR.ForeColor = System.Drawing.Color.OrangeRed;
                ERROR.Visible = true;
                return;
            }

            try
            {
                // Cambia el nombre del archivo si tu base se llama distinto
                string cadenaConexion =
                                        @"Server=.\SQLEXPRESS;
                                        Database=TiendaRopa;
                                        Trusted_Connection=True;";


                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    string consulta = "SELECT COUNT(*) FROM Usuarios WHERE username = @usuario AND password_hash = @contraseña";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@usuario", usuario);
                        comando.Parameters.AddWithValue("@contraseña", contraseña);

                        int resultado = Convert.ToInt32(comando.ExecuteScalar());

                        if (resultado > 0)
                        {
                            // Login correcto
                            ERROR.Visible = false;
                            MessageBox.Show("¡Bienvenid@, " + usuario + "!", "Acceso correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Abre tu formulario principal
                            Panel form = new Panel();  // Asegúrate de tener MainForm creado
                            form.Show();
                            this.Hide();
                        }
                        else
                        {
                            ERROR.Text = "Usuario o contraseña incorrectos.";
                            ERROR.ForeColor = System.Drawing.Color.Red;
                            ERROR.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }
        }
    }
}
