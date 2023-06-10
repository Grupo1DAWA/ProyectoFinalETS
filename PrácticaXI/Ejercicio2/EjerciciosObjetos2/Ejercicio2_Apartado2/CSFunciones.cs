using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_Apartado2
{
    class CSFunciones
    {
        public static Cafeteria CrearCafeteria(int maxPedidos)
        {
            List<Producto> menu = new List<Producto>();

            menu.Add(new Producto("Pulgita de pollo", 2.75m));
            menu.Add(new Producto("Pulgita de jamón", 2.50m));
            menu.Add(new Producto("7Up", 0.99m));
            menu.Add(new Producto("Coca-Cola", 1.25m));
            menu.Add(new Producto("Cruasan", 2.25m));
            menu.Add(new Producto("Bocadillo de pollo", 2.99m));
            menu.Add(new Producto("Monster", 1.25m));
            menu.Add(new Producto("Sandwich", 1.50m));
            menu.Add(new Producto("Palmera de Chocolate", 1.99m));
            menu.Add(new Producto("Agua", 0.75m));
            menu.Add(new Producto("Nachos", 1.99m));

            Cafeteria cafeteria = new Cafeteria(menu, maxPedidos);
            return cafeteria;
        }

        public static void MostrarMenu()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("-    1) Hacer un pedido       -");
            Console.WriteLine("-    2) Servir pedido         -");
            Console.WriteLine("-    3) Hacer caja            -");
            Console.WriteLine("-    0) Salir del programa    -");
            Console.WriteLine("-------------------------------");
        }

        public static int ValidarOpcion()
        {
            int opcion = 0;

            while(!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.Write("ERROR - La opción introducida debe ser un entero: ");
            }
            return opcion;
        }

        
    }
}
