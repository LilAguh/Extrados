using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piezas
{
    public interface IPieza
    {
        bool EsMovimientoValido(int filaInicial, int colInicial, int filaDestino, int colDestino);
        char ObtenerSimbolo();
        bool EsPosicionValida(int fila, int columna, int[] posiciones);
    }
}
