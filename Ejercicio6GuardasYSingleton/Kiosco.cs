using Ejercicio6GuardasYSingleton.bdconnection.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio6GuardasYSingleton
{
    public class Kiosco
    {
        private static Kiosco _instance;
        private bool _enVeda;

        public static Kiosco GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Kiosco();
            }
            return _instance;
        }

        public void SetVeda(bool enVeda)
        {
            _enVeda = enVeda;
        }

        public bool EnVeda()
        {
            return _enVeda;
        }
        public bool Comprar(Usuarios cliente, Productos producto)
        {
            lock(producto)
            {
                if(producto.Stock <= 0)
                {
                    Console.WriteLine($"Compra rechazada: No hay stock para {producto.Producto}");
                    return false;
                }
                if(producto.AptoMenores && cliente.Edad < 18)
                {
                    Console.WriteLine($"Compra rechazada: {cliente.Nombre} no tiene la edad suficiente para comprar {producto.Producto}");
                    return false;
                }
                if(producto.Alcohol && EnVeda())
                {
                    Console.WriteLine($"Compra rechazada: No se puede vender {producto.Producto} porque estamos en veda.");
                    return false;
                }

                producto.Stock--;
                Console.WriteLine($"Compra aceptada: {cliente.Nombre} compro {producto.Producto}");
                return true;
            }
        }
    }
}
