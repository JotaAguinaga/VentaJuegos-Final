using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary.Modelo;

namespace WinFormsApp1
{
    public partial class ReportesProductos : Form
    {
        public ReportesProductos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            menuPrincipal.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            using (var context = new ClassLibrary.Data.AplicationDbContext())
            {
                listBox1.Items.Add("Lista de Productos registrados:");
                foreach (Producto producto in context.Productos)
                {
                    listBox1.Items.Add($"ID: {producto.Id} Nombre: {producto.NombreProducto} Precio:${producto.Precio} Stock: {producto.Stock}");
                }
            }
        }
    }
}
