using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piezas
{
    public class Alfil: IPieza
    {
        public bool EsMovimientoValido(int filaInicial, int colInicial, int filaDestino, int colDestino)
        {
            return Math.Abs(filaInicial - filaDestino) == Math.Abs(colInicial - colDestino);
        }
        public bool EsPosicionValida(int fila, int columna, int[] posiciones)
        {
            for (int c = 0; c < columna; c++) 
            {
                int f = posiciones[c]; 
                if (Math.Abs(f - fila) == Math.Abs(c - columna))
                    return false;
            }
            return true; 
        }
        public char ObtenerSimbolo()
        {
            return 'A';
        }
    }
}
