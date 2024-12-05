

Console.WriteLine("1");
Console.WriteLine("2");
Console.WriteLine("3");

try
{
    Contar();
}
catch(Exception e)
{
    Console.WriteLine("--------------");
    Console.WriteLine("Mensaje: ");
    Console.WriteLine(e.Message);
    Console.WriteLine("StackTrace: ");
    Console.WriteLine(e.StackTrace);
    Console.WriteLine("--------------");
}
Console.WriteLine("12");
Console.WriteLine("13");
Console.WriteLine("14");

void Contar()
{
    Console.WriteLine("4");
    Console.WriteLine("5");
    Contar2();
    Console.WriteLine("10");
    Console.WriteLine("11");
}

void Contar2()
{
    Console.WriteLine("6");
    Console.WriteLine("7");
    throw new Exception("Error al contar: no puede contar mas de 7");
    Console.WriteLine("8");
    Console.WriteLine("9");
}