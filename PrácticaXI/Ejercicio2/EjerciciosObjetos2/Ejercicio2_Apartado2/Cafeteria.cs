using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_Apartado2
{
    class Cafeteria
    {
        private List<Pedido> pedidos { get; set; }
        private List<Pedido> pedidosServidos { get; set; }
        private List<Producto> menuProductos { get; set; }
        private int maxPedidos { get; set; }

        public Cafeteria(List<Producto> menuProductos, int maxPedidos)
        {
            this.pedidos = new List<Pedido>();
            this.pedidosServidos = new List<Pedido>();
            SetMenuProductos(menuProductos);
            SetMaxPedidos(maxPedidos);
        }

        public string MostrarMenu()
        {
            int cont = 1;
            string cadena = "";
            this.menuProductos.ForEach(producto => cadena+=$"{cont++}) {producto}\n");
            return cadena;
        }

        public string MostrarPedidosServidos()
        {
            string cadena = "";
            int cont = 1;
            pedidosServidos.ForEach(pedido =>
            {
                cadena += $"Pedido {cont++}:\n";
                cadena += $"{pedido}";
                cadena += $"Coste total del pedido: {pedido.CosteTotal()}\n";
                cadena += "-------------------------------------------\n";
            });
            return cadena;
        }

        public decimal DineroRecaudado()
        {
            decimal total = 0;
            this.pedidosServidos.ForEach(pedido => total += pedido.CosteTotal());
            return Math.Round(total,2);
        }

        public void IntroducirPedido(Pedido pedido)
        {
            this.pedidos.Add(pedido);
        }

        public void ServirPedido()
        {
            this.pedidosServidos.Add(this.pedidos[0]);
            this.pedidos.RemoveAt(0);
        }

        public bool ComprobarSiHayHueco()
        {
            bool hayHueco = true;
            if (this.pedidos.Count >= 5)
            {
                hayHueco = false;
            }
            return hayHueco;
        }

        public int ValidarNombreProducto(string nombreElegido)
        {
            int indexProducto = 0;

            indexProducto = this.menuProductos.IndexOf(this.menuProductos.Find(product => product.GetNombre().ToLower() == nombreElegido.ToLower()));

            return indexProducto;
        }

        public void SetPedidos(List<Pedido> pedidos)
        {
            if (pedidos.Count > 0)
            {
                this.pedidos = new List<Pedido>();
            }
            else
            {
                this.pedidos = pedidos;
            }
        }

        public List<Pedido> GetPedidos()
        {
            return this.pedidos;
        }

        public void SetPedidosServidos(List<Pedido> pedidosServidos)
        {
            if (pedidosServidos.Count > 0)
            {
                this.pedidosServidos = new List<Pedido>();
            }
            else
            {
                this.pedidosServidos = pedidosServidos;
            }
        }
        public List<Pedido> GetPedidosServidos()
        {
            return this.pedidosServidos;
        }

        public void SetMenuProductos(List<Producto> productos)
        {
            if (productos.Count > 0)
            {
                this.menuProductos = productos;
            }
            else
            {
                this.menuProductos = new List<Producto>();
            }
        }

        public List<Producto> GetMenuProductos()
        {
            return this.menuProductos;
        }

        public void SetMaxPedidos(int maxPedidos)
        {
            if (maxPedidos <= 0)
            {
                this.maxPedidos = 5;
            }
            else
            {
                this.maxPedidos = maxPedidos;
            }
        }
    }
}
