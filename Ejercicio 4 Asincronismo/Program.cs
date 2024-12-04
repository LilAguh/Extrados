


// Sin Lock
//void ContarHasta(int hasta, string codigo, object bloqueador)
//{
//    for (int i = 0; i <= hasta; i++)
//    {
//        Console.WriteLine(codigo + " " + i);
//    }
//}

// Con Lock

void ContarHasta(int hasta, string codigo, object bloqueador)
{
    for (int i = 0; i <= hasta; i++)
    {
        lock(bloqueador)
        {
        Console.WriteLine(codigo + " " + i);
        }
    }
}

async Task ContarHastaAsync(int hasta, string codigo, object bloqueador)
{
    await Task.Run(() => ContarHasta(hasta, codigo, bloqueador));
}

async Task Run()
{
    object bloqueador = new object();
    var task1 = ContarHastaAsync(1000, "linea1", bloqueador);
    var task2 = ContarHastaAsync(1000, "linea2", bloqueador);
    var task3 = ContarHastaAsync(1000, "linea3", bloqueador);

    await Task.WhenAll(task1, task2, task3);
}

//await Run();


//Ejercicio:

//1) generar un array de enteros de tamaño 30000
//2) llenarlo de números aleatorios entre 0 y 45000 
//3) generar 2 hilos que se dividan el array mitad y mitad y busquen el mayor
//4) guardar el mayor en la variable "mayor"
//5) utilizar lock para asegurar la integridad de la respuesta

int[] arrayEnteros = new int[30000];
Random random = new Random();
for (int i = 0; i < arrayEnteros.Length; i++)
{
    arrayEnteros[i] = random.Next(0, 45000);
}

int numeroMayor = 0;
object bloqueador = new object();

async Task<(int mayor, int segundoMayor)> BuscarDosMayoresAsync(int[] array, int inicio, int fin)
{
    int max1 = int.MinValue; // Mayor
    int max2 = int.MinValue; // Segundo mayor

    for (int i = inicio; i < fin; i++)
    {
        if (array[i] > max1)
        {
            max2 = max1; // Actualiza el segundo mayor
            max1 = array[i]; // Actualiza el mayor
        }
        else if (array[i] > max2)
        {
            max2 = array[i]; // Actualiza el segundo mayor si es menor que el mayor
        }
    }

    return (max1, max2);
}

async Task Ejecutar()
{
    int mitad = arrayEnteros.Length / 2;

    // Lanza las tareas
    var tarea1 = BuscarDosMayoresAsync(arrayEnteros, 0, mitad);
    var tarea2 = BuscarDosMayoresAsync(arrayEnteros, mitad, arrayEnteros.Length);

    // Espera a que ambas tareas terminen
    var resultados = await Task.WhenAll(tarea1, tarea2);

    // Combina los resultados para encontrar los dos mayores del array completo
    var mayores = resultados.SelectMany(r => new[] { r.mayor, r.segundoMayor }).OrderByDescending(x => x).Take(2).ToArray();

    Console.WriteLine($"El número mayor es: {mayores[0]}");
    Console.WriteLine($"El segundo mayor es: {mayores[1]}");
}

await Ejecutar();