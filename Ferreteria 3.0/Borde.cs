using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria_3._0
{
    internal static class Borde
    {
      
            private const char EsquinaSuperiorIzquierda = '╔';
            private const char EsquinaSuperiorDerecha = '╗';
            private const char EsquinaInferiorIzquierda = '╚';
            private const char EsquinaInferiorDerecha = '╝';
            private const char BordeHorizontal = '═';
            private const char BordeVertical = '║';
            private const char SeparadorHorizontal = '═';
            private const int AnchoDefault = 80;

            public static void DibujarMarco(string titulo = "", int ancho = AnchoDefault)
            {
                if (ancho < 10) ancho = AnchoDefault;

                // Línea superior
                Console.Write(EsquinaSuperiorIzquierda);
                Console.Write(new string(BordeHorizontal, ancho - 2));
                Console.WriteLine(EsquinaSuperiorDerecha);

                // Título centrado
                if (!string.IsNullOrEmpty(titulo))
                {
                    titulo = $" {titulo} ";
                    int espacios = (ancho - titulo.Length - 2) / 2;
                    string lineaTitulo = $"{BordeVertical}{new string(' ', espacios)}{titulo}{new string(' ', espacios)}";

                    if (lineaTitulo.Length < ancho - 1)
                        lineaTitulo += new string(' ', ancho - lineaTitulo.Length - 1) + BordeVertical;

                    Console.WriteLine(lineaTitulo);

                    // Separador después del título
                    Console.Write(BordeVertical);
                    Console.Write(new string(SeparadorHorizontal, ancho - 2));
                    Console.WriteLine(BordeVertical);
                }
            }

            public static void EscribirEnMarco(string texto, bool centrado = false, bool conBorde = true, int ancho = AnchoDefault)
            {
                if (ancho < 10) ancho = AnchoDefault;

                if (conBorde)
                {
                    if (centrado)
                    {
                        int espacios = (ancho - texto.Length - 2) / 2;
                        string linea = $"{BordeVertical}{new string(' ', espacios)}{texto}{new string(' ', espacios)}";

                        if (linea.Length < ancho - 1)
                            linea += new string(' ', ancho - linea.Length - 1) + BordeVertical;

                        Console.WriteLine(linea);
                    }
                    else
                    {
                        string linea = $"{BordeVertical} {texto.PadRight(ancho - 3)} {BordeVertical}";
                        Console.WriteLine(linea);
                    }
                }
                else
                {
                    Console.WriteLine(texto);
                }
            }

            public static void EscribirCentrado(string texto, int ancho = AnchoDefault)
            {
                EscribirEnMarco(texto, true, true, ancho);
            }

            public static void CerrarMarco(int ancho = AnchoDefault)
            {
                if (ancho < 10) ancho = AnchoDefault;

                Console.Write(EsquinaInferiorIzquierda);
                Console.Write(new string(BordeHorizontal, ancho - 2));
                Console.WriteLine(EsquinaInferiorDerecha);
            }

            public static void DibujarLineaHorizontal(int ancho = AnchoDefault)
            {
                if (ancho < 10) ancho = AnchoDefault;

                Console.Write(BordeVertical);
                Console.Write(new string(SeparadorHorizontal, ancho - 2));
                Console.WriteLine(BordeVertical);
            }

            public static void MostrarMenuConBorde(string titulo, string[] opciones)
            {
                DibujarMarco(titulo);

                foreach (var opcion in opciones)
                {
                    EscribirEnMarco(opcion);
                }

                DibujarLineaHorizontal();
                EscribirEnMarco("Seleccione una opción: ", false, false);
            }
        
    }
}
