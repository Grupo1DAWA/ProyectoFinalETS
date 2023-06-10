using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_Apartado1
{
    class Producto
    {
        private string nombre { get; set; }
        private int stock { get; set; }
        private decimal precio { get; set; }

        public Producto(string nombre, decimal precio, int stock)
        {
            SetNombre(nombre);
            SetPrecio(precio);
            SetStock(stock);
        }

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                this.nombre = "";
            }
            else
            {
                this.nombre = nombre;
            }
        }
        public string GetNombre()
        {
            return this.nombre;
        }
        public void SetStock(int stock)
        {
            if (stock <= 0)
            {
                this.stock = 10;
            }
            else
            {
                this.stock = stock;
            }
        }
        public int GetStock()
        {
            return this.stock;
        }
        public void SetPrecio(decimal precio)
        {
            if (precio <= 0m || ((precio * 100m) - Math.Truncate(precio * 100m) != 0))
            {
                this.precio = 1.99m;
            }
            else
            {
                this.precio = precio;
            }
        }
        public decimal GetPrecio()
        {
            return this.precio;
        }

        public void RellenarStock(int itemMaxStock)
        {
            if (itemMaxStock <= 0)
            {
                this.stock = 10;
            }
            else
            {
                this.stock = itemMaxStock;
            }
        }
        public void RealizarCompra()
        {
            this.stock -= 1;
        }
        public override string ToString()
        {
            return "Nombre: " + this.nombre + " | Precio: " + this.precio + " | Stock: " + this.stock;
        }
    }
}
