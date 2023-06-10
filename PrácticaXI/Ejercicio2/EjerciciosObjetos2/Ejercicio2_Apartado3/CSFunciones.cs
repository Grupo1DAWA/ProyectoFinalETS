using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_Apartado3
{
    class CSFunciones
    {
        public static Tienda CrearTienda(string nombre, string numTelef)
        {
            Tienda tienda = new Tienda(nombre, numTelef);
            Console.Clear();
            Console.WriteLine("La tienda se ha creado correctamente!");
            return tienda;
        }

        public static void AñadirCatalogo(Tienda tienda)
        {
            List<Juego> juegos = new List<Juego>();

            juegos.Add(new Juego("Zelda", 35.70m));
            juegos.Add(new Juego("Mario", 30m));
            juegos.Add(new Juego("Sonic", 27.40m));
            juegos.Add(new Juego("Doom Eternal", 45.50m));
            juegos.Add(new Juego("ComanderKid", 21.90m));

            tienda.SetCatalogoJuegos(juegos);
        }

        public static void MostrarMenu()
        {
            Console.WriteLine("Elija una de las siguientes opciones:");
            Console.WriteLine("1.- Alquilar juego");
            Console.WriteLine("2.- Devolver juego");
            Console.WriteLine("3.- Mostrar  info tienda");
            Console.WriteLine("4.- Mostrar historial");
            Console.WriteLine("0.- Salir");
        }

        public static int PedirOpcion()
        {
            int opcion;

            Console.Write("Introduzca su opción elegida: ");
            while (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.Write("ERROR - La opción debe ser un entero: ");
            }
            return opcion;
        }

        public static List<Juego> JuegosDisponibles(Tienda tienda)
        {
            return tienda.GetCatalogoJuegos().FindAll(juego => juego.GetEstaAlquilado() == false);
        }
        public static void MostrarCatalogo(List<Juego> juegosDisponibles)
        {
            Console.WriteLine("Juegos disponibles:");
            for (int i = 0; i < juegosDisponibles.Count; i++)
            {
                Console.WriteLine($"Juego {i + 1}: {juegosDisponibles[i].GetNombre()} | Precio: {juegosDisponibles[i].GetPrecio()}");
            }
        }

        public static void MostrarInfoTienda(Tienda tienda)
        {
            Console.WriteLine($"Encargado de tienda: {tienda.GetNombreEncargado()}");
            Console.WriteLine($"Telefono de tienda: {tienda.GetNumTelefono()}");

            Console.WriteLine("\nJuegos disponibles:");
            foreach (Juego juego in tienda.GetCatalogoJuegos().FindAll(juego => juego.GetEstaAlquilado() == false))
            {
                Console.WriteLine(juego.MostrarInfoJuegoDisponible());
            }

            Console.WriteLine("\nJuegos alquilados:");
            foreach (Juego juego in tienda.GetCatalogoJuegos().FindAll(juego => juego.GetEstaAlquilado() == true))
            {
                Console.WriteLine(juego.MostrarInfoJuegoAlquilado());
            }
        }
    }
}
