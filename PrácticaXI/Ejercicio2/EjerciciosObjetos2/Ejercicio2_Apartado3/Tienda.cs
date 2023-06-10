using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_Apartado3
{
    class Tienda
    {
        private string NombreEncargado { get; set; }
        private string NumTelefono { get; set; }
        private List<Juego> CatalogoJuegos { get; set; }

        public Tienda()
        {
            CatalogoJuegos = new List<Juego>();
        }

        public Tienda(string nombreEncargado, string numTelefono)
        {
            SetNombreEncargado(nombreEncargado);
            SetNumTelefono(numTelefono);
            CatalogoJuegos = new List<Juego>();
        }

        public static string PedirNombreEncargado()
        {
            string nombreEncargado;
            Console.Write("Introduzca el nombre del encargado de la tienda: ");
            nombreEncargado = Console.ReadLine().Trim();
            while(nombreEncargado == "" || nombreEncargado.Length < 3)
            {
                Console.WriteLine("ERROR - El nombre del encargado no puede estar vacío y tiene que tener 3 letras como mínimo.");
                Console.Write("Introduzca un nombre válido: ");
                nombreEncargado = Console.ReadLine().Trim();
            }
            return nombreEncargado;

        }

        public static string PedirNumTelefono()
        {
            string numTelefono;
            int intNum = 0;
            bool esCorrecto = false;            
            do
            {
                Console.Write("Introduzca el número de telefono de la tienda (debe empezar por 922): ");
                numTelefono = Console.ReadLine().Trim();
                if (numTelefono.Length == 9)
                {
                    if (numTelefono.Substring(0, 3) == "922")
                    {
                        if (int.TryParse(numTelefono, out intNum))
                        {
                            esCorrecto = true;
                        }
                    }
                }

                if (!esCorrecto)
                {
                    Console.WriteLine("ERROR - El número de telefono debe ser numérico, tener 9 dígitos y empezar por \"922\"\n");
                }
            }
            while (!esCorrecto);

            return numTelefono;

        }

        public bool ComprobarAlquilerUsuario(int codUsuario)
        {
            bool tieneAlquiler = false;
            List<Juego> listaAlquilados = new List<Juego>();

            listaAlquilados = this.CatalogoJuegos.FindAll(juego => juego.GetEstaAlquilado() == true);
            listaAlquilados.ForEach(juego =>
            {
                if (juego.GetCompradores()[juego.GetCompradores().Count-1] == codUsuario)
                {
                    tieneAlquiler = true;
                }
            });
            return tieneAlquiler;
        }

        public void SetNombreEncargado(string nombreEncargado)
        {
            if (string.IsNullOrEmpty(nombreEncargado.Trim()) || nombreEncargado.Length < 3)
            {
                this.NombreEncargado = "IDK";
            }
            else
            {
                this.NombreEncargado = nombreEncargado;
            }
        }

        public void SetNumTelefono(string numTelefono)
        {
            if(numTelefono.Substring(0,3) != "922")
            {
                this.NumTelefono = "IDK";
            }
            else
            {
                this.NumTelefono = numTelefono;
            }
        }

        public void SetCatalogoJuegos(List<Juego> catalogoJuegos)
        {
            this.CatalogoJuegos = catalogoJuegos;
        }

        public string GetNombreEncargado()
        {
            return this.NombreEncargado;
        }
        public string GetNumTelefono()
        {
            return this.NumTelefono;
        }
        public List<Juego> GetCatalogoJuegos()
        {
            return this.CatalogoJuegos;
        }
    }
}
