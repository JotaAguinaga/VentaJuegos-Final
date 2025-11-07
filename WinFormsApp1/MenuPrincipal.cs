namespace WinFormsApp1
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)//cliente
        {
            abmClientes abmClientes = new abmClientes();
            abmClientes.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            abmProductos abmProductos = new abmProductos();
            abmProductos.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReportesClientes reportesClientes = new ReportesClientes();
            reportesClientes.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReportesProductos reportesProductos = new ReportesProductos();
            reportesProductos.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\cuent\OneDrive\Escritorio\fondo videojuegos.png");
        }
    }
}
