// See https://aka.ms/new-console-template for more information


using Ejercicio3.bdconnection.DAOs;
using Ejercicio3.bdconnection.Entidades;

DAOUsuarios bd = new DAOUsuarios();
var usuarioByID = bd.ObtenerUsuario(13);

Console.WriteLine(usuarioByID.Nombre);

//List<Usuarios> usuarios = bd.ObtenerTodosLosUsuarios();
//foreach (var usuario in usuarios)
//{
//    Console.WriteLine($"ID: {usuario.ID}, Nombre: {usuario.Nombre}, Edad: {usuario.Edad}");
//}