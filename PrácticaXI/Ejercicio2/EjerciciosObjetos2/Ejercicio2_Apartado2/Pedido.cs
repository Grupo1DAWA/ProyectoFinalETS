using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_Apartado2
{
    class Pedido
    {
        private List<Producto> productos { get; set; }
        private DateTime fechaHora { get; set; }

        public Pedido(List<Producto> productos, DateTime fechaHora)
        {
            SetProductos(productos);
            SetFechaHora(fechaHora);
        }

        public override string ToString()
        {
            string cadena = "";

            cadena += $"Fecha del pedido: {fechaHora}\n Lista de productos:\n";
            productos.ForEach(product => cadena += $"...{product}\n");
            return cadena;
        }

        public decimal CosteTotal()
        {
            decimal total = 0m;

            this.productos.ForEach(product => total += product.GetPrecio());

            return Math.Round(total,2);
        }

        public void SetProductos(List<Producto> productos)
        {
            this.productos = productos;
        }       
        public List<Producto> GetProductos()
        {
            return this.productos;
        }
        public void SetFechaHora(DateTime fechaHora)
        {
            this.fechaHora = fechaHora;
        }
        public DateTime GetFechaHora()
        {
            return this.fechaHora;
        }
    }
}
