using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio5Excepciones
{
    internal class SinSolucionException : Exception
    {
        public SinSolucionException(string mensaje) : base(mensaje) { }
    }
}
