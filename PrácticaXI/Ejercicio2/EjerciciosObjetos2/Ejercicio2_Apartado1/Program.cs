namespace Ejercicio2_Apartado1
{
    class Program
    {
        public static void Main(string[] args)
        {
            const int MAXPRODUCTSTOCK = 10;
            int index = 0;
            int posProduct = -1;
            int opcion = 0;
            decimal saldo = 0m;
            decimal devolver = 0m;
            string strnombre = "";
            string nombreABuscar = "";
            Maquina maquina;
            List<Producto> productosAsequibles;

            maquina = CSFunciones.CrearMaquina();

            Console.WriteLine("Bienvenido a la máquina expendedora, ¿Qué desea hacer?\n");
            do
            {
                posProduct = -1;
                CSFunciones.MostrarMenu();
                Console.Write("\nUsted ha elegido: ");
                while (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.Write("ERROR - La opción debe ser un valor número entero: ");
                }
                Console.Clear();
                switch (opcion)
                {
                    case 1:
                        if (maquina.GetProductos().Count == 0)
                        {
                            Console.WriteLine("ERROR - Ya no quedan productos en la máquina");
                        }
                        else
                        {
                            Console.Write("Introduzca el dinero que va a gastan en la máquina: ");
                            saldo = CSFunciones.ValidarDinero();
                            if (maquina.GetProductos().IndexOf(maquina.GetProductos().Find(producto => producto.GetPrecio() <= saldo)) == -1)
                            {
                                Console.WriteLine("ERROR - No hay productos que puedas comprar con ese saldo.");
                            }
                            else
                            {
                                productosAsequibles = CSFunciones.MostrarProductos(maquina.GetProductos(), saldo);
                                Console.Write("\n¿Qué producto va a eliminar? Introduzca su nombre: ");
                                nombreABuscar = Console.ReadLine().Trim();
                                posProduct = CSFunciones.ValidarProductoABuscar(productosAsequibles, nombreABuscar);
                                if (posProduct == -1)
                                {
                                    Console.WriteLine("ERROR - El producto a buscar no existe en la máquina.\n");
                                }
                                else
                                {
                                    posProduct = CSFunciones.ValidarProductoABuscar(maquina.GetProductos(), nombreABuscar);
                                    if (maquina.GetProductos()[posProduct].GetStock() == 0)
                                    {
                                        Console.WriteLine("ERROR - El producto a buscar no tiene stock en estos momentos.\n");
                                    }
                                    else
                                    {
                                        if (maquina.GetProductos()[posProduct].GetPrecio() == saldo)
                                        {
                                            maquina.GetProductos()[posProduct].RealizarCompra();
                                            Console.WriteLine("La compra se ha realizado con éxito!");
                                        }
                                        else
                                        {
                                            devolver = saldo - maquina.GetProductos()[posProduct].GetPrecio();
                                            maquina.GetProductos()[posProduct].RealizarCompra();
                                            Console.WriteLine("La compra se ha realizado con éxito! Se devuelve al usuario {0} euros",devolver);
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case 2:
                        if (maquina.HuecoNuevoProducto())
                        {
                            CSFunciones.IntroducirProducto(maquina);
                        }
                        else
                        {
                            Console.WriteLine("ERROR - No se puede introducir un nuevo producto, la máquina expendedora está llena.");
                        }
                        break;
                    case 3:
                        if(maquina.GetProductos().Count == 0)
                        {
                            Console.WriteLine("ERROR - Ya no quedan productos en la máquina");
                        }
                        else
                        {
                            CSFunciones.MostrarProductos(maquina.GetProductos());
                            Console.Write("\n¿Qué producto va a eliminar? Introduzca su nombre: ");
                            nombreABuscar = Console.ReadLine().Trim();
                            posProduct = CSFunciones.ValidarProductoABuscar(maquina.GetProductos(), nombreABuscar);
                            if (posProduct == -1)
                            {
                                Console.WriteLine("ERROR - El producto a buscar no existe en la máquina.\n");
                            }
                            else
                            {
                                maquina.EliminarProducto(posProduct);
                                Console.WriteLine("El producto ha sido eliminado con éxito!");
                            }
                        }
                        break;
                    case 4:
                        maquina.GetProductos().ForEach(producto =>
                        {
                            if (producto.GetStock() < MAXPRODUCTSTOCK)
                            {
                                producto.RellenarStock(MAXPRODUCTSTOCK);
                            }
                        });
                        Console.WriteLine("La máquina ha sido reabastecida con éxito!");
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del programa, hasta luego!");
                        break;
                    default:
                        Console.WriteLine("ERROR - Debe elegir una de las opciones dadas anteriormente.\n");
                        break;
                }
            }
            while (opcion != 0);
        }
    }
}
