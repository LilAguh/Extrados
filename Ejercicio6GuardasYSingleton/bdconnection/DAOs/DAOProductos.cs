using Ejercicio6GuardasYSingleton.bdconnection.Entidades;
using MySqlConnector;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ejercicio6GuardasYSingleton.bdconnection.DAOs
{
    // Obtener, Modificar, Crear y Eliminar Productos, modificar el stock
    public class DAOProductos
    {
        string connectionString = "Server=127.0.0.1;Database=kioscoEjercicio;UId=aguh;Password=asd123;";
        public List<Productos> ObtenerTodosLosProductos()
        {
            string query = "SELECT * FROM Productos;";
            using (var connection = new MySqlConnection(connectionString))
            {
                var productos = connection.Query<Productos>(query).AsList();
                return productos;
            }
        }
        public Productos ObtenerProducto(int id)
        {
            string query = "SELECT * FROM Productos where id = @id";
            using (var connection = new MySqlConnection(connectionString))
            {
                var producto = connection.QueryFirstOrDefault<Productos>(query, new { id = id });
                return producto;
            }
        }
        public Productos CrearProducto(string nombre, int precio, int stock, bool aptoMenores, bool alcohol)
        {
            if (stock < 0)
                throw new StockNegativoException("El stock no puede ser negativo.");

            string query = "INSERT INTO Productos (nombre, precio, stock, apto_menores, alcohol) VALUES (@nombre, @precio, @stock, @aptoMenores, @alcohol);";
            string queryProductoCreado = "SELECT * FROM Productos WHERE id = LAST_INSERT_ID();";
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    connection.Execute(query, new { nombre, precio, stock, aptoMenores, alcohol });
                    var nuevoProducto = connection.QueryFirstOrDefault<Productos>(queryProductoCreado);
                    return nuevoProducto;
                }
            }
            catch (StockNegativoException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                throw;
            }
        }

        public Productos ActualizarProducto(int id, string? nombre = null, int? precio = null, int? stock = null, bool? aptoMenores = null, bool? alcohol = null)
        {
            string query = "UPDATE Productos SET nombre = @nombre, precio = @precio, stock = @stock, apto_menores = @aptoMenores, alcohol = @alcohol WHERE id = @id;";
            string queryProducto = "SELECT * FROM Productos WHERE id = @id;";

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    var productoOriginal = connection.QueryFirstOrDefault<Productos>(queryProducto, new { id });
                    string nuevoProducto = nombre ?? productoOriginal.Producto;
                    int nuevoPrecio = precio ?? productoOriginal.Precio;
                    int nuevoStock = stock ?? productoOriginal.Stock;
                    bool cambioAptoMenores = aptoMenores ?? productoOriginal.AptoMenores;
                    bool cambioAlcohol = alcohol ?? productoOriginal.Alcohol;

                    if (nuevoStock < 0)
                        throw new StockNegativoException("El stock no puede ser negativo.");

                    connection.Execute(query, new { producto = nuevoProducto, precio = nuevoPrecio, stock = nuevoStock, aptoMenores = cambioAptoMenores, alcohol = cambioAlcohol, id });
                    var productoActualizado = connection.QueryFirstOrDefault<Productos>(queryProducto, new { id });
                    return productoActualizado;
                }
            }
            catch (StockNegativoException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                throw;
            }
        }
        public bool DesactivarProducto(int id)
        {
            string query = "UPDATE Productos SET activo = 0 WHERE id = @id;";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                int productoEliminado = connection.Execute(query, new { id });
                return productoEliminado > 0;
            }
        }
        public int ModificarStock(int id, int stock)
        {
            if (stock < 0)
                throw new StockNegativoException("El stock no puede ser negativo.");

            string query = "UPDATE productos SET stock = @stock WHERE id = @id;";
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    int stockActualizado = connection.Execute(query, new { stock, id });
                    return stockActualizado;
                }
            }
            catch (StockNegativoException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                throw;
            }
        }
    }
}
