using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_Apartado1
{
    class Maquina
    {
        private List<Producto> productos { get; set; }
        private int numLineas { get; set; }
        private int capacidadLinea { get; set; }

        public Maquina(List<Producto> productos, int numFilas, int capacidadFila)
        {
            this.productos = productos;
            this.numLineas = numFilas;
            this.capacidadLinea = capacidadFila;
        }

        public void SetProducto(Producto producto)
        {
            this.productos.Add(producto);
        }
        public List<Producto> GetProductos()
        {
            return this.productos;
        }
        public void SetNumLineas(int numFilas)
        {
            if(numFilas <= 0)
            {
                this.numLineas = 20;
            }
            else
            {
                this.numLineas = numFilas;
            }
        }
        public int GetNumLineas()
        {
            return this.numLineas;
        }
        public void SetCapacidadFila(int capacidadFila)
        {
            if (capacidadFila <= 0)
            {
                this.capacidadLinea = 10;
            }
            else
            {
                this.capacidadLinea = capacidadFila;
            }
        }
        public int GetCapacidadFila()
        {
            return this.capacidadLinea;
        }
        public bool HuecoNuevoProducto()
        {
            return this.productos.Count < this.numLineas;
        }
        public void EliminarProducto(int index)
        {
            if (index >= this.productos.Count)
            {
                this.productos.RemoveAt(this.productos.Count-1);
            }
            else
            {
                this.productos.RemoveAt(index);
            }
        }
    }
}
