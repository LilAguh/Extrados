using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio6GuardasYSingleton.bdconnection.Entidades
{
    public class Productos
    {
        public int ID { get; set; }
        public string Producto { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }
        public bool AptoMenores { get; set; }
        public bool Alcohol { get; set; }
    }
}
