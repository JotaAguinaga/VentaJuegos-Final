using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Data;
using ClassLibrary.Modelo;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Repo
{
    public class RepoProducto
    {
        public static void AggProducto(Producto producto)
        {
            using (var context = new AplicationDbContext())
            {
                context.Productos.Add(producto);
                context.SaveChanges();
            }

        }
        public static void ModProducto(int id, string productoN, decimal precio, int stock)
        {
            using (var context = new AplicationDbContext())
            {
                var productobuscado = context.Productos.FirstOrDefault(p => p.Id == id);
                if (productobuscado != null)
                {
                    productobuscado.NombreProducto = productoN;
                    productobuscado.Precio = precio;
                    productobuscado.Stock = stock;
                    context.SaveChanges();
                }
            }

        }
        public static void DeleteProducto(int id)
        {
            using (var context = new AplicationDbContext())
            {
                var productobuscado = context.Productos.FirstOrDefault(p => p.Id == id);
                if (productobuscado != null)
                {
                    context.Productos.Remove(productobuscado);
                    context.SaveChanges();
                }

            }
        }
    }
}
