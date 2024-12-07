using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones_GuardasYSingleton
{
    public class Animal
    {
        //atributes
        private static Animal _instace = null;
        public int cantidadPatas { get; set; }
        public int anosVida { get; set; }

        public static Animal instance
        {
            get
            {
                Console.WriteLine("Accediendo a la instancia de animal");
                if (_instace == null)
                {
                    Console.WriteLine("Instancia no encontrada, creando instancia");
                    _instace = new Animal();
                }
                Console.WriteLine("Devolviendo instancia");
                return _instace;
            }
        }

        //Constructor
        private Animal()
        {
            this.cantidadPatas = cantidadPatas;

        }

        //Estados
        public void Caminar(int metros)
        {
            Console.WriteLine("el animal utilizo sus " + cantidadPatas + " para caminar " + metros + " metros.");

        }
        public void Hablar()
        {
            Console.WriteLine("Sonido animal");
        }
    }
}
