using Ejercicio3.bdconnection.Entidades;
using MySqlConnector;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3.bdconnection.DAOs
{
    internal class DAOUsuarios
    {
        string connectionString = "Server=127.0.0.1;Database=ejercicio3DB;UId=aguh;Password=asd123;";
        public List<Usuarios> ObtenerTodosLosUsuarios()
        {
            string query = "SELECT * FROM Usuarios WHERE activo = 1;";
            using (var connection = new MySqlConnection(connectionString))
            {
                var usuarios = connection.Query<Usuarios>(query).AsList();
                return usuarios;
            }
        }
        public Usuarios ObtenerUsuario(int id)
        {
            string query = "SELECT * FROM Usuarios where id = @id and activo = 1;";
            using (var connection = new MySqlConnection(connectionString))
            {
                var usuario = connection.QueryFirstOrDefault<Usuarios>(query, new { id = id});
                return usuario;
            }
        }
        public Usuarios CrearUsuario(string nombre, int edad)
        {
            string query = "INSERT INTO Usuarios (nombre, edad) VALUES (@nombre, @edad);";
            string queryUsuarioCreado = "SELECT * FROM Usuarios WHERE id = LAST_INSERT_ID();";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute(query, new { nombre = nombre, edad = edad });
                var usuario = connection.QueryFirstOrDefault<Usuarios>(queryUsuarioCreado);
                return usuario;
            }
        }

        public Usuarios ActualizarUsuario(int id, string? nombre = null, int? edad = null)
        {
            string query = "UPDATE usuarios SET nombre = @nombre, edad = @edad WHERE id = @id;";
            string queryUsuarioActualizado = "SELECT * FROM Usuarios WHERE id = @id;";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                //Se buscan los datos originales y en caso de no quere hacer cambio a alguno se deja el original
                var usuario = connection.QueryFirstOrDefault<Usuarios>(queryUsuarioActualizado, new { id = id });
                string nuevoNombre = nombre ?? usuario.Nombre;
                int nuevaEdad = edad ?? usuario.Edad;


                connection.Execute(query, new { nombre = nuevoNombre, edad = nuevaEdad, id = id });
                var usuarioActualizado = connection.QueryFirstOrDefault<Usuarios>(queryUsuarioActualizado, new {id = id});
                return usuarioActualizado;
            }
        }
        public bool DesactivarUsuario(int id)
        {
            string query = "UPDATE usuarios SET activo = 0 WHERE id = @id;";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                int usuarioEliminado = connection.Execute(query, new { id });
                return usuarioEliminado > 0;
            }
        }
    }
}
