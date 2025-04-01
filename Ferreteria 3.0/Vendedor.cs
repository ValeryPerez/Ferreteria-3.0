using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria_3._0
{
    internal class Vendedor
    {
        #region atributos
        public string Codigo { get; }
        public string Nombre { get; private set; }
        public int VentasRealizadas { get; private set; }
        public decimal TotalVendido { get; private set; }
        public bool Activo { get; private set; }

        #endregion

        #region constructores
        public Vendedor(string codigo, string nombre)
        {
            if (!Validaciones.ValidarCodigo(codigo))
                throw new ArgumentException("El código debe tener exactamente 3 dígitos.");

            if (!Validaciones.ValidarNombre(nombre))
                throw new ArgumentException("El nombre debe tener entre 2 y 50 caracteres.");

            Codigo = codigo;
            Nombre = nombre;
            VentasRealizadas = 0;
            TotalVendido = 0;
            Activo = true;
        }
        #endregion

        #region metodos

        //Metodo para registrar una venta
        public void RegistrarVentas(decimal monto)
        {
            if (!Activo)
                throw new InvalidOperationException("El vendedor está inactivo y no puede registrar ventas.");

            if (monto <= 0)
                throw new ArgumentException("El monto debe ser mayor que cero.");

            VentasRealizadas++;
            TotalVendido += monto;
        }
        
        // Metodo para Despedir un vendedor
        public void Despedir()
        {
            Activo = false;
        }
        // Metodo para recontratar un vendedor
        public void Recontratar()
        {
            Activo = true;
        }

        public override string ToString()
        {
            return $"Código: {Codigo}, Nombre: {Nombre}, Ventas: {VentasRealizadas}, Total: {TotalVendido:C}, Estado: {(Activo ? "Activo" : "Inactivo")}";
        }
    }
    #endregion

}

