using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Modelo;

namespace ClassLibrary.Repo
{
    public class RepoCliente
    {
        public static void AgregarCliente(Cliente cliente)
        {
            using (var context = new Data.AplicationDbContext())
            {
                context.Clientes.Add(cliente);
                context.SaveChanges();
            }
        }
        public static void ModCliente(int id,string nombre,string apellido, string correo)
        {
            using (var context = new Data.AplicationDbContext())
            {
                var cliente = context.Clientes.FirstOrDefault(c => c.id == id);
                if (cliente != null)
                {
                    cliente.nombre = nombre;
                    cliente.apellido = apellido;
                    cliente.Correo = correo;
                    context.SaveChanges();
                }
            }
        }
    }
}