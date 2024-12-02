using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Piezas;

namespace Ejercicio2
{
    
    // Clase que representa el tablero de ajedrez
    public class Tablero
    {
        public int tamaño;

        public Tablero(int tamaño)
        {
            this.tamaño = tamaño;
        }
        // Método recursivo para resolver el problema de colocar N reinas
        public void Resolver(int columna,IPieza pieza, int tamaño, int[] posiciones, ref int contadorSoluciones)
        {
            if (columna == tamaño) // Si todas las reinas han sido colocadas
            {
                contadorSoluciones++; // Incrementa el contador de soluciones
                DibujarTablero(posiciones, pieza); // Dibuja la solución
                return;
            }

            for (int fila = 0; fila < tamaño; fila++) // Intenta colocar una reina en cada fila de la columna actual
            {
                if (pieza.EsPosicionValida(fila, columna, posiciones)) // Verifica si la posición es válida
                {
                    posiciones[columna] = fila; // Coloca la reina
                    Resolver(columna + 1, pieza, tamaño, posiciones, ref contadorSoluciones); // Llama recursivamente para la siguiente columna
                    posiciones[columna] = -1; // Retira la reina (backtracking)
                }
            }
        }

        // Dibuja el tablero con las posiciones dadas y la pieza proporcionada
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
