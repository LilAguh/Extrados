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
        public List<Usuarios> ObtenerTodosLosUsuarios()
        {
            string query = "SELECT * FROM Usuarios;";
            string connectionString = "Server=127.0.0.1;Database=ejercicio3DB;UId=aguh;Password=asd123;";
            using (var connection = new MySqlConnection(connectionString))
            {
                var usuarios = connection.Query<Usuarios>(query).AsList();
                return usuarios;
            }
        }
        public Usuarios ObtenerUsuario(int id)
        {
            string query = "SELECT * FROM Usuarios where ID = @id;";
            string connectionString = "Server=127.0.0.1;Database=ejercicio3DB;UId=aguh;Password=asd123;";
            using (var connection = new MySqlConnection(connectionString))
            {
                var usuario = connection.QueryFirstOrDefault<Usuarios>(query, new {id = id});
                return usuario;
            }
        }
    }
}
