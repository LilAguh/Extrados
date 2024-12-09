

// Crear un programa de operacion de un kiosco
// En la base de datos: 
//      Productos: Precio, Stock, AptoMenores, Alcohol
//      Usuario: Nombre, Edad
// Kiosco:
//      * Debe ser Singleton
//      * Metodo Comprar(), atributos: Cliente(Usuario), Producto
//      * Si producto no es AptoMenores, Comprobar edad usuario
//      * Si producto es Alcohol, Comprobar que no estemos en veda
//      * Funcion EnVeda(), que return sea booleano (hardcorear return)
//      * Procesar si Stock > 1
//      * Cualquier otro control utilizar condicion de Guarda
//      * Al vender producto Stock--
//      * Utilizar Lock para protejer Stock, No vender por debajo de Stock <= 0
//      * Ejecutar con multiples hilos (5 minimo, haciendo compras simultaneas)
//      * Como resultado por consola mostrar:
//              - Si la compra fue rechazada y la razon
//              - Si la compra fue aceptada
//              - El stock que quede del producto

using Ejercicio6GuardasYSingleton;
using Ejercicio6GuardasYSingleton.bdconnection.DAOs;
using Ejercicio6GuardasYSingleton.bdconnection.Entidades;

class Program
{
    static void Main(string[] args)
    {
        var kiosco = Kiosco.GetInstance();
        var daoUsuarios = new DAOUsuarios();
        var daoProductos = new DAOProductos();

        Console.WriteLine("Bienvenido al sistema del Kiosco.");

        // Obtener y seleccionar un usuario
        Console.WriteLine("\nUsuarios disponibles:");
        var usuarios = daoUsuarios.ObtenerTodosLosUsuarios();
        for (int i = 0; i < usuarios.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {usuarios[i].Nombre} (Edad: {usuarios[i].Edad})");
        }

        Console.Write("\nSeleccione un usuario por su número: ");
        int usuarioSeleccionado = int.Parse(Console.ReadLine()) - 1;
        var cliente = usuarios[usuarioSeleccionado];

        // Preguntar si hay veda
        Console.Write("\n¿Estamos en veda? (s/n): ");
        string vedaRespuesta = Console.ReadLine().Trim().ToLower();
        bool enVeda = vedaRespuesta == "s";
        kiosco.SetVeda(enVeda); // Implementar un método en Kiosco para establecer la veda

        // Obtener y seleccionar un producto
        Console.WriteLine("\nProductos disponibles:");
        var productos = daoProductos.ObtenerTodosLosProductos();
        for (int i = 0; i < productos.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {productos[i].Producto} (Stock: {productos[i].Stock}, Precio: {productos[i].Precio})");
        }

        Console.Write("\nSeleccione un producto por su número: ");
        int productoSeleccionado = int.Parse(Console.ReadLine()) - 1;
        var producto = productos[productoSeleccionado];

        // Preguntar la cantidad
        Console.Write("\n¿Cuántas unidades desea comprar?: ");
        int cantidad = int.Parse(Console.ReadLine());

        // Realizar las compras en paralelo
        Console.WriteLine("\nProcesando compras...");
        Parallel.For(0, cantidad, i =>
        {
            bool compraExitosa = kiosco.Comprar(cliente, producto);

            if (compraExitosa)
            {
                daoProductos.ModificarStock(producto.ID, producto.Stock);
                Console.WriteLine($"Compra {i + 1} realizada con éxito. Stock restante: {producto.Stock}");
            }
            else
            {
                Console.WriteLine($"Compra {i + 1} fallida.");
            }
        });

        Console.WriteLine("\nTodas las compras han sido procesadas.");
        Console.WriteLine("\nPresione cualquier tecla para salir.");
        Console.ReadKey();
    }
}