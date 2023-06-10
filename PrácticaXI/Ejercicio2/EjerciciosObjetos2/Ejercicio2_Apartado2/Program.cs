namespace Ejercicio2_Apartado2
{
    class Program
    {
        public static void Main(string[] args)
        {
            const int MAXPEDIDOS = 5;
            int opcion = 0;
            int indexProducto = 0;
            int contPedidosServidos = 1;
            string nombreProducto = "";
            Cafeteria cafeteria;
            List<Producto> productosPedidos = new List<Producto>();
            

            cafeteria = CSFunciones.CrearCafeteria(MAXPEDIDOS);

            Console.WriteLine("Bienvenido a la cafetería del César Manrique, ¿que desea?");

            do
            {
                CSFunciones.MostrarMenu();

                Console.Write("\nUsted a elegido: ");
                opcion = CSFunciones.ValidarOpcion();
                Console.Clear();

                switch (opcion)
                {
                    case 0:
                        Console.WriteLine("Saliendo del programa, hasta luego!");
                        break;
                    case 1:
                        if (cafeteria.ComprobarSiHayHueco())
                        {
                            productosPedidos = new List<Producto>();
                            do
                            {
                                Console.WriteLine(cafeteria.MostrarMenu());
                                Console.Write("Introduzca el nombre del producto que " +
                                    "quiere (Introduzca \"FIN\" para finalizar el pedido): ");
                                nombreProducto = Console.ReadLine().Trim();
                                Console.Clear();
                                if (string.IsNullOrEmpty(nombreProducto))
                                {
                                    Console.WriteLine("ERROR - El nombre del producto a elegir no puede ser nulo o vacío.\n");
                                }
                                else
                                {
                                    if (nombreProducto.ToLower() != "fin")
                                    {
                                        indexProducto = cafeteria.ValidarNombreProducto(nombreProducto);
                                        if (indexProducto != -1)
                                        {
                                            Console.WriteLine("El producto elegido se ha añadido al pedido.\n");
                                            productosPedidos.Add(cafeteria.GetMenuProductos()[indexProducto]);
                                        }
                                        else
                                        {
                                            Console.WriteLine("ERROR - El producto introducido no existe en el menú.\n");
                                        }
                                    }
                                    else
                                    {
                                        if(productosPedidos.Count == 0)
                                        {
                                            Console.WriteLine("El pedido ha sido cancelado con éxito!");
                                        }
                                        else
                                        {
                                            Pedido pedido = new Pedido(productosPedidos, DateTime.Now);
                                            cafeteria.IntroducirPedido(pedido);
                                            Console.WriteLine("El pedido se ha finalizado con éxito!");
                                        }
                                    }
                                }
                            }
                            while (nombreProducto.ToLower() != "fin");
                        }
                        else
                        {
                            Console.WriteLine("No se pueden realizar más pedidos.");
                        }
                        break;
                    case 2:
                        if(cafeteria.GetPedidos().Count == 0)
                        {
                            Console.WriteLine("La cafetería no tiene ningún pedido pendiente que servir.");
                        }
                        else
                        {
                            cafeteria.ServirPedido();
                            Console.WriteLine($"El pedido {contPedidosServidos++} ha sido servido y su coste" +
                                $" total es: {cafeteria.GetPedidosServidos()[cafeteria.GetPedidosServidos().Count-1].CosteTotal()}");
                        }
                        break;
                    case 3:
                        if(cafeteria.GetPedidosServidos().Count == 0)
                        {
                            Console.WriteLine("Todavía no se ha servido ni recaudado nada.");
                        }
                        else
                        {
                            Console.WriteLine(cafeteria.MostrarPedidosServidos());
                            Console.WriteLine($"Total de dinero recaudado: {cafeteria.DineroRecaudado()}");
                            Console.ReadKey(true);
                            Console.Clear();
                        }
                        break;
                    default:
                        Console.WriteLine("ERROR - La opción introducida debe ser una de las mostradas en el menú.");
                        break;
                }
                Console.WriteLine(" ");
            }
            while (opcion != 0);
        }
    }
}
