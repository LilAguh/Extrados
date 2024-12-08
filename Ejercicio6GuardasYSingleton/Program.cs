

// Crear un programa de operacion de un kiosco
// En la base de datos: 
//      Productos: Precio, Stock, AptoMenores, Alcohol
//      Usuario: Nombre, Edad
// Kiosco:
//      * Debe ser Singleton
//      * Metodo Comprar(), atributos: Cliente(Usuario), Producto
//      * Si producto no es AptoMenores, Comprobar edad usuario
//      * Si producto es Alcohol, Comprobar que no estemos en veda
//      * Funcion EnVeda(), que return sea booleano (hardcorear return)
//      * Procesar si Stock > 1
//      * Cualquier otro control utilizar condicion de Guarda
//      * Al vender producto Stock--
//      * Utilizar Lock para protejer Stock, No vender por debajo de Stock <= 0
//      * Ejecutar con multiples hilos (5 minimo, haciendo compras simultaneas)
//      * Como resultado por consola mostrar:
//              - Si la compra fue rechazada y la razon
//              - Si la compra fue aceptada
//              - El stock que quede del producto