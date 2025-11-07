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

namespace WinFormsApp1
{
    public partial class ReportesClientes : Form
    {
        public ReportesClientes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            menuPrincipal.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
                listBox1.Items.Clear();
            using (var context = new AplicationDbContext())
            {
                listBox1.Items.Add("Lista de Clientes registrados:");
                foreach (Cliente cliente in context.Clientes)
                {
                    listBox1.Items.Add($"ID: {cliente.id} Correo: {cliente.Correo}");
                }
            }
        }
    }
}
