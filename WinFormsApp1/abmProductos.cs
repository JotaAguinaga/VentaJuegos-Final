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
using ClassLibrary.Repo;

namespace WinFormsApp1
{
    public partial class abmProductos : Form
    {
        public abmProductos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            menuPrincipal.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e) // Agregar producto
        {
            string nombreProducto = textBox1.Text;
            decimal precio = decimal.Parse(textBox2.Text);
            int stock = int.Parse(textBox3.Text);

            Producto nuevoProducto = new Producto(nombreProducto, precio, stock);
            RepoProducto.AggProducto(nuevoProducto);
            MessageBox.Show("Producto agregado:\nNombre: " + nombreProducto + "\nPrecio:$" + precio + "\nStock: " + stock);

            listBox1.Items.Clear();
            //listBox1.Items.Add($"ID: {nuevoProducto.Id} Nombre: {nuevoProducto.NombreProducto} Precio: {nuevoProducto.Precio} Stock: {nuevoProducto.Stock}");
            using (var context = new ClassLibrary.Data.AplicationDbContext())
            {
                foreach (Producto producto in context.Productos)
                {
                    listBox1.Items.Add($"ID: {producto.Id} Nombre: {producto.NombreProducto} Precio:${producto.Precio} Stock: {producto.Stock}");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e) //modificar producto
        {
            if (int.TryParse(textBox7.Text, out int id))
            {
                string NombreProducto = textBox4.Text;
                decimal Precio = decimal.Parse(textBox5.Text);
                int Stock = int.Parse(textBox6.Text);

                RepoProducto.ModProducto(id, NombreProducto, Precio, Stock);
                MessageBox.Show("Producto modificado:\nID: " + id + "\nNombre: " + NombreProducto + "\nPrecio:$" + Precio + "\nStock: " + Stock);
                listBox1.Items.Clear();
                using (var context = new ClassLibrary.Data.AplicationDbContext())
                {
                    foreach (Producto producto in context.Productos)
                    {
                        listBox1.Items.Add($"ID: {producto.Id} Nombre: {producto.NombreProducto} Precio:${producto.Precio} Stock: {producto.Stock}");
                    }
                }
            }
            else
            {
                MessageBox.Show("ID inválido.");
            }
        }

        private void button4_Click(object sender, EventArgs e) //eliminar producto por id 
        {
            if (int.TryParse(textBox8.Text, out int id))
            {
                RepoProducto.DeleteProducto(id);
                MessageBox.Show("Producto eliminado con ID: " + id);
                listBox1.Items.Clear();
                using (var context = new ClassLibrary.Data.AplicationDbContext())
                {
                    foreach (Producto producto in context.Productos)
                    {
                        listBox1.Items.Add($"ID: {producto.Id} Nombre: {producto.NombreProducto} Precio:${producto.Precio} Stock: {producto.Stock}");
                    }
                }
            }
            else
            {
                MessageBox.Show("ID inválido.");
            }
        }

        private void button3_Click(object sender, EventArgs e) //mostrar listbox productos
        {
            listBox1.Items.Clear();
            using (var context = new ClassLibrary.Data.AplicationDbContext())
            {
                foreach (Producto producto in context.Productos)
                {
                    listBox1.Items.Add($"ID: {producto.Id} Nombre: {producto.NombreProducto} Precio:${producto.Precio} Stock: {producto.Stock}");
                }
            }
        }
    }
}
