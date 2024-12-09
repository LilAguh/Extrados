using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio6GuardasYSingleton
{
    public class StockNegativoException : Exception
    {
        public StockNegativoException(string mensaje) : base(mensaje) { }
    }
}
