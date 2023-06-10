using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_Apartado2
{
    class Producto
    {
        private string nombre { get; set; }
        private decimal precio { get; set; }

        public Producto(string nombre, decimal precio)
        {
            SetNombre(nombre);
            SetPrecio(precio);
        }

        public override string ToString()
        {
            return $"Nombre: {nombre} || Precio: {precio}";
        }

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre.Trim()))
            {
                nombre = "";
            }
            else
            {
                this.nombre = nombre.Trim();
            }
        }
        public string GetNombre()
        {
            return this.nombre;
        }
        public void SetPrecio(decimal precio)
        {
            if (precio <= 0)
            {
                precio = 1.99m;
            }
            else
            {
                if(precio*100 - Math.Truncate(precio*100) != 0)
                {
                    this.precio = Math.Round(precio,2);
                }
                else
                {
                    this.precio = precio;
                }
            }
        }
        public decimal GetPrecio()
        {
            return this.precio;
        }
    }
}
