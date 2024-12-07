

using Excepciones_GuardasYSingleton;

//Console.WriteLine("1");
//Console.WriteLine("2");
//Console.WriteLine("3");

//try
//{
    //Contar();
//}
//catch(MiExcepcion e)
//{
//    Console.WriteLine("Se disparo MiExcepcion");
//}
//catch(Exception e)
//{
//    Console.WriteLine("Se disparo exception");
//}
//Console.WriteLine("12");
//Console.WriteLine("13");
//Console.WriteLine("14");

//void Contar()
//{
//    Console.WriteLine("4");
//    Console.WriteLine("5");
//    Contar2();
//    Console.WriteLine("10");
//    Console.WriteLine("11");
//}

//void Contar2()
//{
//    Console.WriteLine("6");
//    Console.WriteLine("7");
//    throw new MiExcepcion();
//    Console.WriteLine("8");
//    Console.WriteLine("9");
//}



//Codigo normal
void VenderAlcohol(int edad, bool veda)
{
    if(edad >= 18 & !veda)
    {
        Console.WriteLine("Se le puede vender alcohol.");
    }
    else
    {
        Console.WriteLine("No vender alcohol.");
    }
}

VenderAlcohol(21, true);

Console.WriteLine("----------------------------------------");


// Codico con Guarda
//se utiliza para evitar la anidación de IF. cada nuevo nivel de IF que se tenga en el codigo
//agrega complejidad para leerlo y debe ser evitado de ser posible.
void VenderAlcoholGuarda(int edad, bool veda)
{
    //  en vez de pensar en el codigo de forma “si esto se cumple, corre el codigo”,
    //  pensar en forma de “si esto no se cumple, tira error”
    if (edad < 18 || veda)
        throw new Exception("No vender alcohol.");
    Console.WriteLine("Se le puede vender alcohol.");
}

//VenderAlcoholGuarda(21, true);


//Animal ani1 = new Animal(5);
//Animal ani2 = new Animal(6);
//Animal ani3 = new Animal(8);
//Animal dato = 4;

//Console.WriteLine(ani1.cantidadPatas);
//Console.WriteLine(ani2.cantidadPatas);
//Console.WriteLine(ani3.cantidadPatas);
//Console.WriteLine(Animal.dato);


// Un objeto singleton es un objeto del que solo puede existir una instancia
// Como vemos al ejecutar la instancia es creada una sola vez
// Se puede modificar pero no instanciar mas de una, salvo que sea asincrono y rompa la instancia
var asd1 = Animal.instance;
asd1.cantidadPatas = 1;
var asd2 = Animal.instance;
asd1.cantidadPatas = 2;
var asd3 = Animal.instance;
asd1.cantidadPatas = 3;

Console.WriteLine(asd1.cantidadPatas);