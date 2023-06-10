namespace Ejercicio2_Apartado3
{
    class Program
    {
        public static void Main(string[] args)
        {
            string nombreEncargado;
            string numTelefono;
            int opcion = 0;
            int codUsuario = 0;
            Tienda tienda;
            List<Juego> juegosDisponibles = new List<Juego>();

            Console.WriteLine("Bienvenido!\n");

            nombreEncargado = Tienda.PedirNombreEncargado();
            numTelefono = Tienda.PedirNumTelefono();

            tienda = CSFunciones.CrearTienda(nombreEncargado, numTelefono);
            CSFunciones.AñadirCatalogo(tienda);

            do
            {
                CSFunciones.MostrarMenu();
                opcion = CSFunciones.PedirOpcion();
                Console.Clear();
                switch (opcion)
                {
                    case 0:
                        Console.WriteLine("Saliendo del programa, hasta luego!");
                        break;
                    case 1:
                        codUsuario = Juego.PedirCodUsuario();
                        if (!tienda.ComprobarAlquilerUsuario(codUsuario))
                        {
                            juegosDisponibles = CSFunciones.JuegosDisponibles(tienda);
                            CSFunciones.MostrarCatalogo(juegosDisponibles);
                            Console.Write("\nIntroduzca su opción: ");
                            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion <= 0 || opcion > juegosDisponibles.Count)
                            {
                                Console.Write("ERROR - La opción debe ser una de las mostradas: ");
                            }
                            juegosDisponibles[opcion - 1].AlquilarJuego(codUsuario);
                            Console.WriteLine("El juego se ha alquilado con éxito!");
                        }
                        else
                        {
                            Console.WriteLine("El usuario tendrá que devolver el juego que ya tiene alquilado si desea alquilar otro.");
                        }
                        break;
                    case 2:
                        codUsuario = Juego.PedirCodUsuario();
                        if (tienda.ComprobarAlquilerUsuario(codUsuario))
                        {
                            Juego juegoADevolver = tienda.GetCatalogoJuegos().Find(juego =>
                            juego.GetEstaAlquilado() == true && juego.GetCompradores()[juego.GetCompradores().Count - 1] == codUsuario);
                            Console.WriteLine("Se va a devoler:");
                            Console.WriteLine(juegoADevolver.MostrarInfoJuegoDisponible());
                            juegoADevolver.DevolverJuego();

                        }
                        else
                        {
                            Console.WriteLine("El usuario no tiene ningún juego alquilado.");
                        }
                        break;
                    case 3:
                        CSFunciones.MostrarInfoTienda(tienda);
                        break;
                    case 4:
                        Console.WriteLine("Elija un juego para ver su historial:");
                        CSFunciones.MostrarCatalogo(tienda.GetCatalogoJuegos());
                        Console.Write("\nIntroduzca su opción: ");
                        while (!int.TryParse(Console.ReadLine(), out opcion) || opcion <= 0 || opcion > tienda.GetCatalogoJuegos().Count)
                        {
                            Console.Write("ERROR - La opción debe ser una de las mostradas: ");
                        }
                        Console.Clear();
                        Console.WriteLine(tienda.GetCatalogoJuegos()[opcion - 1].MostrarCompradoresYTotal());

                        break;
                    default:
                        Console.WriteLine("ERROR - Debe de introducir una opción de las ya mostradas.");
                        break;
                }
                Console.WriteLine("\nPulse cualquier tecla para continuar...");
                Console.ReadKey(true);
                Console.Clear();
            }
            while (opcion != 0);
        }
    }
}
