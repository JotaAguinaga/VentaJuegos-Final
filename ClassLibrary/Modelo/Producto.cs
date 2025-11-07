namespace ClassLibrary.Modelo
{
    public class Producto
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public Producto(string nombreProducto, decimal precio, int stock)
        {
            this.NombreProducto = nombreProducto;
            this.Precio = precio;
            this.Stock = stock;
        }
    }
}
