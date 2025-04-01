using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ferreteria_3._0
{
    static class Validaciones
    {
        public static bool ValidarCodigo(string codigo)
        {
            return Regex.IsMatch(codigo, @"^\d{3}$");
        }

        public static bool ValidarNombre(string nombre)
        {
            return !string.IsNullOrWhiteSpace(nombre) && nombre.Length >= 2 && nombre.Length <= 50;
        }

        public static bool ValidarPrecio(string input, out decimal precio)
        {
            return decimal.TryParse(input, out precio) && precio > 0;
        }

        public static bool ValidarStock(string input, out int stock)
        {
            return int.TryParse(input, out stock) && stock >= 0;
        }

        public static bool ValidarOpcionMenu(string input, int min, int max, out int opcion)
        {
            return int.TryParse(input, out opcion) && opcion >= min && opcion <= max;
        }

    }
}
