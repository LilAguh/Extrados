using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Piezas;

namespace Ejercicio5Excepciones
{
    public class Tablero
    {
        public int tamaño;

        public Tablero(int tamaño)
        {
            this.tamaño = tamaño;
        }
        public void Resolver(int columna, IPieza pieza, int tamaño, int[] posiciones, ref int contadorSoluciones)
        {
            if (columna == tamaño)
            {
                contadorSoluciones++;
                DibujarTablero(posiciones, pieza);
                return;
            }

            for (int fila = 0; fila < tamaño; fila++)
            {
                if (pieza.EsPosicionValida(fila, columna, posiciones))
                {
                    posiciones[columna] = fila;
                    Resolver(columna + 1, pieza, tamaño, posiciones, ref contadorSoluciones);
                    posiciones[columna] = -1;
                }
            }
        }
        public void DibujarTablero(int[] posiciones, IPieza pieza)
        {
            Console.WriteLine("      A   B   C   D   E   F   G   H"); // Encabezado de columnas
            Console.WriteLine("    ┌───┬───┬───┬───┬───┬───┬───┬───┐"); // Línea superior del tablero

            for (int fila = 0; fila < tamaño; fila++)
            {
                Console.Write($"{fila + 1}   │"); // Número de fila en la izquierda
                for (int col = 0; col < tamaño; col++)
                {
                    if (posiciones[col] == fila)
                        Console.Write($" {pieza.ObtenerSimbolo()} │"); // Dibuja la pieza en la posición
                    else
                        Console.Write("   │"); // Espacio vacío
                }
                Console.WriteLine();

                if (fila < tamaño - 1)
                    Console.WriteLine("    ├───┼───┼───┼───┼───┼───┼───┼───┤"); // Línea divisoria entre filas
                else
                    Console.WriteLine("    └───┴───┴───┴───┴───┴───┴───┴───┘"); // Línea inferior del tablero
            }
        }
    }
}
