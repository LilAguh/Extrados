using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piezas
{
    public class SinSolucion : IPieza
    {
        // Verifica si un movimiento es válido para una torre
        public bool EsMovimientoValido(int filaInicial, int colInicial, int filaDestino, int colDestino)
        {
            // La torre solo puede moverse en la misma fila o columna
            return filaInicial == filaDestino || colInicial == colDestino;
        }

        // Verifica si una posición es válida para esta torre
        public bool EsPosicionValida(int fila, int columna, int[] posiciones)
        {
            return false; // Siempre devuelve false, por lo tanto, ninguna posición será válida
        }

        // Devuelve el símbolo de la torre
        public char ObtenerSimbolo()
        {
            return '?'; // Representación visual de la torre
        }

        public string ObtenerNombre()
        {
            return "Pieza sin solucion ejemplo";
        }
    }
}
