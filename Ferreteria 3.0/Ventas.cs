using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria_3._0
{
    internal class Ventas
    {
        #region atributos
        public string CodigoProducto { get; }
        public string CodigoVendedor { get; }
        public int Cantidad { get; }
        public DateTime Fecha { get; }
        public decimal Total { get; }
        #endregion

        #region constructores
        public Ventas(string codigoProducto, string codigoVendedor, int cantidad, decimal total)
        {
            if (!Validaciones.ValidarCodigo(codigoProducto))
                throw new ArgumentException("Código de producto inválido.");

            if (!Validaciones.ValidarCodigo(codigoVendedor))
                throw new ArgumentException("Código de vendedor inválido.");

            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor que cero.");

            if (total <= 0)
                throw new ArgumentException("El total debe ser mayor que cero.");

            CodigoProducto = codigoProducto;
            CodigoVendedor = codigoVendedor;
            Cantidad = cantidad;
            Total = total;
            Fecha = DateTime.Now;
        }
        #endregion
    }
}
