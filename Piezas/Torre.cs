using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piezas
{
    public class Torre: IPieza
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
            for (int c = 0; c < columna; c++) // Recorre todas las columnas anteriores
            {
                int f = posiciones[c]; // Fila donde ya hay una torre colocada en la columna `c`

                // Si hay una torre en la misma fila o columna, no es una posición válida
                if (f == fila || c == columna)
                    return false;
            }
            return true; // Si pasa todas las verificaciones, la posición es válida
        }

        // Devuelve el símbolo de la torre
        public char ObtenerSimbolo()
        {
            return 'T'; // Representación visual de la torre
        }
    }
}
