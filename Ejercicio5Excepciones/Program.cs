


using Ejercicio5Excepciones;
using Piezas;

class Program
{
    static void Main(string[] args)
    {
        int tamañoTablero = 8;
        int contadorSoluciones = 0;
        Tablero tablero = new Tablero(tamañoTablero);

        //Reina reina = new Reina();


        try
        {
            IPieza reina = new Piezas.Reina();
            IPieza torre = new Piezas.Torre();
            IPieza alfil = new Piezas.Alfil();
            IPieza sinSolucion = new Piezas.SinSolucion();
            int[] posiciones = new int[tamañoTablero];
            for (int i = 0; i < tamañoTablero; i++) posiciones[i] = -1; // Inicializa las posiciones

            tablero.Resolver(0, sinSolucion, tamañoTablero, posiciones, ref contadorSoluciones);
            if (contadorSoluciones == 0) throw new SinSolucionException($"No se encontró solución para la pieza *aca va el nombre de la pieza* en un tablero de {tamañoTablero}x{tamañoTablero}.");
            Console.WriteLine($"Proceso terminado. Total de soluciones: {contadorSoluciones}");
        }
        catch (SinSolucionException e)
        {
            Console.WriteLine($"Error: {e.Message}");
            //Console.WriteLine($"StackTrace: {e.StackTrace}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ocurrió un error inesperado: {e.Message}");
        }

        // Pausa para evitar que la consola se cierre inmediatamente
        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }

}
