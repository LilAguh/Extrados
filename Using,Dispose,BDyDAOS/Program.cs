// See https://aka.ms/new-console-template for more information
using Using_Dispose_BDyDAOS;

Console.WriteLine("iniciando");

using(Botella bot= new Botella())
{
    bot.LlenarBotella();
}
