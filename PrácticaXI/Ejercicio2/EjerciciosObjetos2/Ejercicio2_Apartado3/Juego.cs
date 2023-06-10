using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_Apartado3
{
    class Juego
    {
        private string Nombre { get; set; }
        private decimal Precio { get; set; }
        private bool EstaAlquilado { get; set; }
        private List<int> Compradores { get; set; }

        public Juego()
        {
            SetEstaAlquilado(false);
            Compradores = new List<int>();
        }

        public Juego(string nombre, decimal precio)
        {
            SetNombre(nombre);
            SetPrecio(precio);
            SetEstaAlquilado(false);
            Compradores = new List<int>();
        }

        public static int PedirCodUsuario()
        {
            int codUsuario = 0;

            Console.Write("Introduzca el código de usuario (3 dígitos): ");
            while(!int.TryParse(Console.ReadLine(), out codUsuario) || codUsuario < 100 || codUsuario > 999)
            {
                Console.Write("ERROR - El código de usuario debe ser de 3 dígitos: ");
            }
            return codUsuario;
        }

        public string MostrarInfoJuegoDisponible()
        {
            return $"Nombre: {this.Nombre} - Precio: {this.Precio}";
        }
        public string MostrarInfoJuegoAlquilado()
        {
            return $"Nombre: {this.Nombre} - Precio: {this.Precio} -- Usuario que lo tiene: {this.Compradores[this.Compradores.Count-1]}";
        }
        public string MostrarCompradoresYTotal()
        {
            string cadena = "";
            int numCompradores = 0;

            cadena += "Los compradores de este juego han sido:\n";
            this.Compradores.ForEach(comprador => 
            {
                cadena += $"--CodUsuario: {comprador}\n";
                numCompradores++;
            });
            cadena += $"---------------------------\nTotal de dinero ganado con este juego: {Math.Round(this.Precio * numCompradores,2)}";
            return cadena;
        }

        public void AlquilarJuego(int codUsuario)
        {
            this.EstaAlquilado = true;
            this.Compradores.Add(codUsuario);
        }
        public void DevolverJuego()
        {
            this.EstaAlquilado = false;
        }

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre.Trim()))
            {
                this.Nombre = "";
            }
            else
            {
                this.Nombre = nombre;
            }
        }
        public void SetPrecio(decimal precio)
        {
            if(precio <= 0)
            {
                this.Precio = 20;
            }
            else
            {
                this.Precio = precio;
            }
        }

        public void SetEstaAlquilado(bool estaAlquilado)
        {
            this.EstaAlquilado = estaAlquilado;
        }
        public void SetCompradores(List<int> compradores)
        {
            this.Compradores = compradores;
        }

        public string GetNombre()
        {
            return this.Nombre;
        }
        public decimal GetPrecio()
        {
            return this.Precio;
        }
        public bool GetEstaAlquilado()
        {
            return this.EstaAlquilado;
        }

        public List<int> GetCompradores()
        {
            return this.Compradores;
        }
    }
}
