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
    public partial class Inventario : Form
    {
        public Inventario()
        {
            InitializeComponent();
        }
        private void Inventario_Load(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Inventario_Load_1(object sender, EventArgs e)
        {
            // Cadena de conexión (ajústala a tu entorno):
            string cadenaConexion =
                @"Server=.\SQLEXPRESS;
      Database=TiendaRopa;
      Trusted_Connection=True;";

            // Consulta a la tabla "Productos" (o como se llame tu tabla de inventario)
            string consulta = "SELECT codigo,nombre, stock, talla FROM Productos;";

            // Llenar el DataTable
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(consulta, con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            // Asignar el DataTable al DataGridView
            dgvProductos.DataSource = dt;
        }
    }
}
