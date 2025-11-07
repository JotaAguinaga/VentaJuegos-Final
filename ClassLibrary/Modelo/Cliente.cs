using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Modelo
{
    public class Cliente
    {
       public int id { get; set; }
       public string nombre { get; set; }
        public string apellido { get; set; }
        public string Correo { get; set; }

        public Cliente(string nombre,string apellido, string correo)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.Correo = correo;
        }
    }
}
