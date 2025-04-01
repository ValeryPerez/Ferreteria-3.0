using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria_3._0
{
    internal class Inventario
    {
        #region atributos
        private Dictionary<string, Producto> inventario;
        #endregion

        #region constructores
        public Inventario()
        {
            inventario = new Dictionary<string, Producto>();
        }
        #endregion

        #region Metodos

        // Metodo para agregar un producto a el diccionario
        public void AgregarProducto(Producto producto)
        {
            if (inventario.ContainsKey(producto.Codigo))
            {
                Console.WriteLine("Error, ya existe un producto con ese código");
            }

            else
            {
                inventario.Add(producto.Codigo, producto);
                Console.WriteLine("Producto Agregado");
            }

        }

        // Metodo para buscar un producto segun su codigo
        public Producto BuscarPorCodigo(string codigo)
        {
            if (inventario.TryGetValue(codigo, out Producto producto))
            {
                return producto;
            }
            else
            {
                Console.WriteLine("Producto no encontrado");
                return null;
            }
        }

        // Metodo para buscar un producto segun su nombre

        public IEnumerable<Producto> BuscarPorNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return Enumerable.Empty<Producto>();
            }
            else
            {
                return inventario.Values
               .Where(p => p.Nombre.IndexOf(nombre, StringComparison.OrdinalIgnoreCase) >= 0)
               .OrderBy(p => p.Nombre)
               .ToList();
            }

        }

        // Metodo para eliminar un producto
        public bool EliminarProducto(string codigo)
        {
            if (inventario.TryGetValue(codigo, out var producto))
            {
                inventario.Remove(codigo);
                return true;
            }
            return false;
        }
        
        //Metodo para mostar todos los productos
        public List<Producto> MostarProductos()
        {
            return inventario.Values.ToList();
        }

        // Metodo para mostrar una lista de los productos que se deben surtir
        public List<Producto> ObtenerProductosASurtir()
        {
            return inventario.Values
                .Where(p => p.StockActual <= p.StockMinimo)
                .ToList();
        }

        // Metodo para buscar los productos mas vendidos 
        public List<Producto> ProductosMasVendidos(int cantidad = 3)
        {
            return inventario.Values
                .OrderByDescending(p => p.CantidadVentas)
                .Take(cantidad)
                .ToList();
        }

        //Metodo para buscar los productos menos vendidos

        public List<Producto> ProductosMenosVendidos(int cantidad = 3)
        {
            return inventario.Values
                .Where(p => p.CantidadVentas >= 0)
                .OrderBy(p => p.CantidadVentas)
                .Take(cantidad)
                .ToList();
        }

        public int TotalProductosVendidos()
        {
            return inventario.Values.Sum(p => p.CantidadVentas);
        }


        #endregion

    }

}   
           
