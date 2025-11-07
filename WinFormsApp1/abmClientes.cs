using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary.Data;
using ClassLibrary.Modelo;
using ClassLibrary.Repo;

namespace WinFormsApp1
{
    public partial class abmClientes : Form
    {
        public abmClientes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // volver
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            menuPrincipal.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e) // apellido
        {

        }

        private void label1_Click(object sender, EventArgs e)//no usar
        {

        }

        private void button2_Click(object sender, EventArgs e) // Agregar
        {
            string nombre = textBox1.Text;
            string apellido = textBox2.Text;
            string email = textBox3.Text;
            using (var context = new AplicationDbContext())
            {
                listBox1.Items.Clear();
                var clientebuscado = context.Clientes.FirstOrDefault(c => c.Correo == email);
                if (clientebuscado != null)
                {
                    MessageBox.Show("El email ya está registrado.");
                    return;
                }
                else
                {
                    Cliente nuevoCliente = new Cliente(nombre, apellido, email);
                    RepoCliente.AgregarCliente(nuevoCliente);
                }
                foreach (Cliente cliente in context.Clientes)
                {
                    listBox1.Items.Add($"ID: {cliente.id} nombre: {cliente.nombre} Apellido: {cliente.apellido} Correo: {cliente.Correo}");
                }

            }
            // Aquí puedes agregar la lógica para guardar el cliente en la base de datos o en una lista
            MessageBox.Show("Cliente agregado:\nNombre: " + nombre + "\nApellido: " + apellido + "\nEmail: " + email);

        }

        private void button3_Click(object sender, EventArgs e) //modificar
        {
            if (int.TryParse(textBox4.Text, out int id))
            {
                string nombre = textBox5.Text;
                string apellido = textBox6.Text;
                string correo = textBox7.Text;
                RepoCliente.ModCliente(id, nombre, apellido, correo);
                MessageBox.Show("Cliente modificado correctamente.");
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID válido.");
            }
            listBox1.Items.Clear();
            using (var context = new AplicationDbContext())
            {
                foreach (Cliente cliente in context.Clientes)
                {
                    listBox1.Items.Add($"ID: {cliente.id} nombre: {cliente.nombre} Apellido: {cliente.apellido} Correo: {cliente.Correo}");
                }

            }
        }

        private void button4_Click(object sender, EventArgs e) //mostrar
        {
            listBox1.Items.Clear();
            using (var context = new AplicationDbContext())
            {
                foreach (Cliente cliente in context.Clientes)
                {
                    listBox1.Items.Add($"ID: {cliente.id} nombre: {cliente.nombre} Apellido: {cliente.apellido} Correo: {cliente.Correo}");
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
