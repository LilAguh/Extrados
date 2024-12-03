// See https://aka.ms/new-console-template for more information


using Ejercicio3.bdconnection.DAOs;
using Ejercicio3.bdconnection.Entidades;

DAOUsuarios bd = new DAOUsuarios();

//Obtiene una persona por el id
//var usuarioByID = bd.ObtenerUsuario(13);
//Console.WriteLine(usuarioByID.Nombre);

//Obtiene lista de todos los usuarios
//List<Usuarios> usuarios = bd.ObtenerTodosLosUsuarios();
//foreach (var usuario in usuarios)
//{
//Console.WriteLine($"ID: {usuario.ID}, Nombre: {usuario.Nombre}, Edad: {usuario.Edad}");
//}

//Crea un nuevo usuario
//var crearUsuario = bd.CrearUsuario("Juan", 33);
//Console.WriteLine($"ID: {crearUsuario.ID}, Nombre: {crearUsuario.Nombre}, Edad: {crearUsuario.Edad}");

//Actualiza un usuario
//var actualizarUsuario = bd.ActualizarUsuario(26,"Adrian");
//Console.WriteLine($"ID: {actualizarUsuario.ID}, Nombre: {actualizarUsuario.Nombre}, Edad: {actualizarUsuario.Edad}");

//Elimina logicamente el usuario del sistema
var eliminarUsuario = bd.DesactivarUsuario(22);
if (eliminarUsuario)
    Console.WriteLine("El usuario fue eliminado");