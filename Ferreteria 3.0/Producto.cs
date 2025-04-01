using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria_3._0
{
    internal class Producto
    {
        #region atributos
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public string Descripcion { get; set; }
        public int CantidadVentas { get; set; }
        #endregion

        #region costructores
        public Producto(string codigo, string nombre, string descripcion, decimal precio, int stockActual, int stockMinimo)
        {
           
            if (!Validaciones.ValidarCodigo(codigo))
                throw new ArgumentException("El código debe tener exactamente 3 dígitos.");

            if (!Validaciones.ValidarNombre(nombre))
                throw new ArgumentException("El nombre debe tener entre 2 y 50 caracteres.");

            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción no puede estar vacía.");

            if (precio <= 0)
                throw new ArgumentException("El precio debe ser mayor que cero.");

            if (stockActual < 0)
                throw new ArgumentException("El stock actual no puede ser negativo.");

            if (stockMinimo < 0)
                throw new ArgumentException("El stock mínimo no puede ser negativo.");

            if (stockMinimo > stockActual)
                throw new ArgumentException("El stock mínimo no puede ser mayor al stock actual.");

            // Asignación de valores
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            StockActual = stockActual;
            StockMinimo = stockMinimo;
            CantidadVentas = 0;
        }

        public Producto() { }

        #endregion

        #region metodos 

        //Metodo para actualizar el stock de un producto
        public void ActualizarStock(int cantidad)
        {
            if ( cantidad < 0)
                throw new InvalidOperationException("No se puede reducir el stock por debajo de cero.");

            StockActual = cantidad;
        }

        // Metodo para modificar el precio de un producto
        public void ModificarPrecio(decimal nuevoPrecio)
        {
            if (nuevoPrecio <= 0)
                throw new ArgumentException("El precio debe ser mayor que cero.");

            Precio = nuevoPrecio;
        }

        // Metodo para registrar la venta de un producto
        public void RegistrarVenta(int cantidad)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad vendida debe ser mayor que cero.");

            if (StockActual < cantidad)
                throw new InvalidOperationException("No hay suficiente stock para realizar la venta.");

            StockActual -= cantidad;
            CantidadVentas += cantidad;
        }

        public override string ToString()
        {
            return $"Código: {Codigo}, Nombre: {Nombre}, Precio: {Precio}, Stock: {StockActual}, Mínimo: {StockMinimo}, Vendidos: {CantidadVentas}";
        }
    }

    #endregion


}

