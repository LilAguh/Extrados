using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Using_Dispose_BDyDAOS
{
    public class Botella: IDisposable
    {
        public string estado{ get; set; }

        public Botella()
        {
            estado = "Vacia";
        }

        // Nunca se debe eliminar el objeto botella "Llena"
        public void LlenarBotella()
        {
            estado = "Llena";
            Console.WriteLine($"Botella {estado}");
        }

        public void VaciarBotella()
        {
            estado = "Vacia";
            Console.WriteLine($"Botella {estado}");
        }

        public void Dispose()
        {
            Console.WriteLine("Presiona cualquier tecla para eliminar la botella");
            Console.ReadKey();
            Console.WriteLine("*aca se deberia de ejecutar el dispose para gatillar el vaciador*");
            this.VaciarBotella();
            Console.WriteLine("*aca se elimina la botella una vez vacia*");
        }
    }
}
