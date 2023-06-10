using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_Apartado1
{
    class CSFunciones
    {
        public static Maquina CrearMaquina()
        {
            List<Producto> productos = new List<Producto>();

            productos.Add(new Producto("RedBull", 2.99m, 4));
            productos.Add(new Producto("Eneryeti", 1m, 7));
            productos.Add(new Producto("Agua", 0.75m, 10));
            productos.Add(new Producto("Cafe", 1.99m, 6));
            productos.Add(new Producto("Monster", 3.50m, 5));
            productos.Add(new Producto("Doritos", 3.99m, 7));
            productos.Add(new Producto("Lays", 2.99m, 8));
            productos.Add(new Producto("Pringles", 1.99m, 6));
            productos.Add(new Producto("Pipas Grefusa", 2.50m, 3));
            productos.Add(new Producto("Barritas energéticas", 1.25m, 10));
            productos.Add(new Producto("KitKat", 3m, 2));
            productos.Add(new Producto("Huevos Kinder", 1m, 5));
            productos.Add(new Producto("PetaZetas", 2.50m, 6));
            productos.Add(new Producto("Chicles Orbit", 2m, 4));
            productos.Add(new Producto("Palmeras de Chocolate", 2.50m, 6));
            productos.Add(new Producto("Rufles", 1.75m, 6));
            productos.Add(new Producto("MiniEscudos", 2m, 1));
            productos.Add(new Producto("Coca-Cola", 1.99m, 4));
            productos.Add(new Producto("Pepsi", 2.99m, 7));
            productos.Add(new Producto("7Up", 3.99m, 3));

            Maquina maquina = new Maquina(productos, 20, 10);
            return maquina;
        }
        public static bool ValidarNombre(string nombre, List<Producto> maquinaStock)
        {
            int index = 0;
            bool error = false;

            if (nombre == "")
            {
                error = true;
            }
            else
            {
                index = maquinaStock.IndexOf(maquinaStock.Find(producto => producto.GetNombre().ToLower() == nombre.ToLower()));

                if (index == -1)
                {
                    error = false;
                }
                else
                {
                    error = true;
                }
            }
            return error;
        }
        public static decimal ValidarDinero()
        {
            decimal precio = 0m;

            while (!decimal.TryParse(Console.ReadLine(), out precio) || precio <= 0 || (precio * 100m) - Math.Truncate(precio * 100m) != 0)
            {
                Console.Write("ERROR - La cantidad monetaria introducida es inválida, debe ser decimal positiva con dos decimales como máximo: ");
            }

            return precio;
        }
        public static int ValidarStock(Maquina maquina)
        {
            int stock = 0;

            while (!int.TryParse(Console.ReadLine(), out stock) || stock <= 0 || stock > maquina.GetCapacidadFila())
            {
                Console.Write("ERROR - La cantidad de stock introducida es inválida, debe ser un entero positivo entre 0 y {0}: ",maquina.GetCapacidadFila());
            }

            return stock;
        }
        public static void IntroducirProducto(Maquina maquina)
        {
            string nombre;
            decimal precio = 0m;
            int stock = 0;
            bool sePudo = false;
            do
            {
                Console.Write("Introduzca el nombre del producto: ");

                nombre = Console.ReadLine().Trim();
                if (ValidarNombre(nombre, maquina.GetProductos()))
                {
                    Console.WriteLine("ERROR - El nombre del producto es vacío o ya ha sido introducido anteriormente.\n");
                }
                else
                {
                    Console.Write("\nIntroduzca el precio del producto: ");
                    precio = ValidarDinero();
                    Console.Write("\nIntroduzca el stock del producto: ");
                    stock = ValidarStock(maquina);
                    Console.Clear();
                    sePudo = true;
                    maquina.SetProducto(new Producto(nombre, precio, stock));
                    Console.WriteLine("Producto introducido con éxito!\n");
                }
            }
            while (!sePudo);
        }
        public static void MostrarMenu()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("-     1) Comprar un producto     -");
            Console.WriteLine("-     2) Añadir un producto      -");
            Console.WriteLine("-     3) Eliminar un product     -");
            Console.WriteLine("-     4) Reabastecer maquina     -");
            Console.WriteLine("-     0) Salir del programa      -");
            Console.WriteLine("----------------------------------");
        }
        public static void MostrarProductos(List<Producto> maquinaStock)
        {
            int index = 1;

            maquinaStock.ForEach(delegate (Producto producto) 
            {
                Console.WriteLine(index + ") " + producto.ToString());
                index++;
            });
        }
        public static List<Producto> MostrarProductos(List<Producto> maquinaStock,decimal saldo)
        {
            int index = 1;
            List<Producto> productosAsequibles;

            productosAsequibles = maquinaStock.FindAll(producto => producto.GetPrecio() <= saldo);

            productosAsequibles.ForEach(producto =>
            {
                Console.WriteLine(index + ") " + producto.ToString());
                index++;
            });

            return productosAsequibles;
        }
        public static int ValidarProductoABuscar(List<Producto> maquinaStock, string nombreABuscar)
        {
            int index = 0;


            if (nombreABuscar == "")
            {
                return -1;
            }
            else
            {
                index = maquinaStock.IndexOf(maquinaStock.Find(producto => producto.GetNombre().ToLower() == nombreABuscar.ToLower()));
                return index;
            }
        }
    }
}
