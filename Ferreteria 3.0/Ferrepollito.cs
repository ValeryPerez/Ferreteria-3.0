using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria_3._0
{
    internal class Ferrepollito
    {
        #region atributos
        private Inventario inventario;
        private List<Ventas> ventas;
        private Dictionary<string, Vendedor> vendedores;

        #endregion

        #region constructores
        public Ferrepollito()
        {
            inventario = new Inventario();
            ventas = new List<Ventas>();
            vendedores = new Dictionary<string, Vendedor>();
        }
        #endregion

        #region metodos
        public void MenuPrincipal()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE GESTIÓN DE FERRETERÍA ===");
                Console.WriteLine("1. Gestión de Productos");
                Console.WriteLine("2. Gestión de Vendedores");
                Console.WriteLine("3. Procesar Venta");
                Console.WriteLine("4. Reportes");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                string input = Console.ReadLine();
                if (!Validaciones.ValidarOpcionMenu(input, 0, 4, out int opcion))
                {
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    Console.ReadKey();
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        MenuProductos();
                        break;
                    case 2:
                        MenuVendedores();
                        break;
                    case 3:
                        ProcesarVenta();
                        break;
                    case 4:
                        MenuReportes();
                        break;
                    case 0:
                        return;
                }
            }
        }

        private void MenuProductos()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE PRODUCTOS ===");
                Console.WriteLine("1. Ingresar nuevo producto");
                Console.WriteLine("2. Buscar producto");
                Console.WriteLine("3. Modificar stock/precio");
                Console.WriteLine("4. Eliminar producto");
                Console.WriteLine("5. Listar todos los productos");
                Console.WriteLine("0. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                string input = Console.ReadLine();
                if (!Validaciones.ValidarOpcionMenu(input, 0, 5, out int opcion))
                {
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    Console.ReadKey();
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        IngresarNuevoProducto();
                        break;
                    case 2:
                        BuscarProducto();
                        break;
                    case 3:
                        ModificarProducto();
                        break;
                    case 4:
                        EliminarProducto();
                        break;
                    case 5:
                        ListaProductos();
                        break;
                    case 0:
                        return;
                }
            }
        }

        private void MenuVendedores()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE VENDEDORES ===");
                Console.WriteLine("1. Registrar nuevo vendedor");
                Console.WriteLine("2. Buscar vendedor");
                Console.WriteLine("3. Despedir vendedor");
                Console.WriteLine("4. Recontratar vendedor");
                Console.WriteLine("5. Listar todos los vendedores");
                Console.WriteLine("0. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                string input = Console.ReadLine();
                if (!Validaciones.ValidarOpcionMenu(input, 0, 5, out int opcion))
                {
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    Console.ReadKey();
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        RegistrarVendedor();
                        break;
                    case 2:
                        BuscarVendedor();
                        break;
                    case 3:
                        DespedirVendedor();
                        break;
                    case 4:
                        RecontratarVendedor();
                        break;
                    case 5:
                        ListarVendedores();
                        break;
                    case 0:
                        return;
                }
            }
        }

        private void MenuReportes()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== REPORTES ===");
                Console.WriteLine("1. Productos más vendidos");
                Console.WriteLine("2. Productos menos vendidos");
                Console.WriteLine("3. Productos a surtir");
                Console.WriteLine("4. Vendedores por desempeño");
                Console.WriteLine("0. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                string input = Console.ReadLine();
                if (!Validaciones.ValidarOpcionMenu(input, 0, 4, out int opcion))
                {
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    Console.ReadKey();
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        MostrarProductosMasVendidos();
                        break;
                    case 2:
                        MostrarProductosMenosVendidos();
                        break;
                    case 3:
                        MostrarProductosASurtir();
                        break;
                    case 4:
                        MostrarVendedoresPorDesempeno();
                        break;
                    case 0:
                        return;
                }
            }
        }

        private void IngresarNuevoProducto()
        {
            Console.Clear();
            Console.WriteLine("=== INGRESAR NUEVO PRODUCTO ===");

            try
            {
                string codigo;
                do
                {
                    Console.Write("Código del producto (3 dígitos): ");
                    codigo = Console.ReadLine();
                    if (!Validaciones.ValidarCodigo(codigo))
                        Console.WriteLine("El código debe tener exactamente 3 dígitos.");
                } while (!Validaciones.ValidarCodigo(codigo));

                string nombre;
                do
                {
                    Console.Write("Nombre del producto (2-50 caracteres): ");
                    nombre = Console.ReadLine();
                    if (!Validaciones.ValidarNombre(nombre))
                        Console.WriteLine("El nombre debe tener entre 2 y 50 caracteres.");
                } while (!Validaciones.ValidarNombre(nombre));

                Console.Write("Descripción: ");
                string descripcion = Console.ReadLine();

                decimal precio;
                string inputPrecio;
                do
                {
                    Console.Write("Precio: ");
                    inputPrecio = Console.ReadLine();
                    if (!Validaciones.ValidarPrecio(inputPrecio, out precio))
                        Console.WriteLine("Ingrese un precio válido (mayor a 0).");
                } while (!Validaciones.ValidarPrecio(inputPrecio, out precio));

                int stockActual;
                string inputStock;
                do
                {
                    Console.Write("Stock actual: ");
                    inputStock = Console.ReadLine();
                    if (!Validaciones.ValidarStock(inputStock, out stockActual))
                        Console.WriteLine("Ingrese un stock válido (mayor o igual a 0).");
                } while (!Validaciones.ValidarStock(inputStock, out stockActual));

                int stockMinimo;
                string inputMinimo;
                do
                {
                    Console.Write("Stock mínimo: ");
                    inputMinimo = Console.ReadLine();
                    if (!Validaciones.ValidarStock(inputMinimo, out stockMinimo))
                        Console.WriteLine("Ingrese un stock mínimo válido (mayor o igual a 0).");
                } while (!Validaciones.ValidarStock(inputMinimo, out stockMinimo));

                Producto nuevoProducto = new Producto(codigo, nombre, descripcion, precio, stockActual, stockMinimo);
                inventario.AgregarProducto(nuevoProducto);

                Console.WriteLine("\n¡Producto agregado con éxito!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }

            Console.ReadKey();
        }

        private void BuscarProducto()
        {
            Console.Clear();
            Console.WriteLine("=== BUSCAR PRODUCTO ===");
            Console.WriteLine("1. Buscar por código");
            Console.WriteLine("2. Buscar por nombre");
            Console.Write("Seleccione una opción: ");

            string input = Console.ReadLine();
            if (!Validaciones.ValidarOpcionMenu(input, 1, 2, out int opcion))
            {
                Console.WriteLine("Opción no válida.");
                Console.ReadKey();
                return;
            }

            if (opcion == 1)
            {
                string codigo;
                do
                {
                    Console.Write("Ingrese el código del producto (3 dígitos): ");
                    codigo = Console.ReadLine();
                    if (!Validaciones.ValidarCodigo(codigo))
                        Console.WriteLine("El código debe tener exactamente 3 dígitos.");
                } while (!Validaciones.ValidarCodigo(codigo));

                var producto = inventario.BuscarPorCodigo(codigo);
                if (producto != null)
                {
                    Console.WriteLine("\n=== DETALLE DEL PRODUCTO ===");
                    Console.WriteLine(producto);
                }
                else
                {
                    Console.WriteLine("No se encontró ningún producto con ese código.");
                }
            }
            else
            {
                Console.Write("Ingrese el nombre del producto: ");
                string busqueda = Console.ReadLine();

                var resultados = inventario.BuscarPorNombre(busqueda).ToList();

                if (resultados.Any())
                {
                    Console.WriteLine("\nResultados de la búsqueda:");
                    foreach (var producto in resultados)
                    {
                        Console.WriteLine("\n=== DETALLE DEL PRODUCTO ===");
                        Console.WriteLine(producto);
                    }

                }
                else
                {
                    Console.WriteLine("\nNo se encontraron productos con ese nombre.");
                }
            }
            Console.ReadKey();
        }

        private void ModificarProducto()
        {
            Console.Clear();
            Console.WriteLine("=== MODIFICAR PRODUCTO ===");

            string codigo;
            do
            {
                Console.Write("Ingrese el código del producto (3 dígitos): ");
                codigo = Console.ReadLine();
                if (!Validaciones.ValidarCodigo(codigo))
                    Console.WriteLine("El código debe tener exactamente 3 dígitos.");
            } while (!Validaciones.ValidarCodigo(codigo));

            var producto = inventario.BuscarPorCodigo(codigo);
            if (producto == null)
            {
                Console.WriteLine("No se encontró ningún producto con ese código.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\n=== MODIFICAR ===");
            Console.WriteLine(producto);

            Console.WriteLine("\n1. Modificar stock");
            Console.WriteLine("2. Modificar precio");
            Console.Write("Seleccione qué desea modificar: ");

            string input = Console.ReadLine();
            if (!Validaciones.ValidarOpcionMenu(input, 1, 2, out int opcion))
            {
                Console.WriteLine("Opción no válida.");
                Console.ReadKey();
                return;
            }

            try
            {
                if (opcion == 1)
                {
                    int cantidad;
                    string inputCantidad;
                    do
                    {
                        Console.Write("Ingrese el nuevo stock actual del producto: ");
                        inputCantidad = Console.ReadLine();
                        if (!Validaciones.ValidarStock(inputCantidad, out cantidad))
                            Console.WriteLine("Ingrese un valor numérico válido.");
                    } while (!Validaciones.ValidarStock(inputCantidad, out cantidad));

                    producto.ActualizarStock(cantidad);
                    Console.WriteLine($"Stock actualizado. Nuevo stock: {producto.StockActual}");
                }
                else
                {
                    decimal nuevoPrecio;
                    string inputPrecio;
                    do
                    {
                        Console.Write("Ingrese el nuevo precio: ");
                        inputPrecio = Console.ReadLine();
                        if (!Validaciones.ValidarPrecio(inputPrecio, out nuevoPrecio))
                            Console.WriteLine("Ingrese un precio válido (mayor a 0).");
                    } while (!Validaciones.ValidarPrecio(inputPrecio, out nuevoPrecio));

                    producto.ModificarPrecio(nuevoPrecio);
                    Console.WriteLine($"Precio actualizado. Nuevo precio: {producto.Precio}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.ReadKey();
        }

        private void EliminarProducto()
        {
            Console.Clear();
            Console.WriteLine("=== ELIMINAR PRODUCTO ===");

            string codigo;
            do
            {
                Console.Write("Ingrese el código del producto (3 dígitos): ");
                codigo = Console.ReadLine();
                if (!Validaciones.ValidarCodigo(codigo))
                    Console.WriteLine("El código debe tener exactamente 3 dígitos.");
            } while (!Validaciones.ValidarCodigo(codigo));

            if (inventario.EliminarProducto(codigo))
            {
                Console.WriteLine("Producto eliminado con éxito.");
            }
            else
            {
                Console.WriteLine("No se encontró ningún producto con ese código.");
            }

            Console.ReadKey();
        }

        private void ListaProductos()
        {
            Console.Clear();
            Console.WriteLine("=== LISTADO DE PRODUCTOS ===");

            var productos = inventario.MostarProductos();
            if (productos.Count == 0)
            {
                Console.WriteLine("No hay productos registrados.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Código\tNombre\t\tPrecio\tStock\tMínimo\tVendidos");
            foreach (var producto in productos)
            {
                Console.WriteLine($"{producto.Codigo}\t{producto.Nombre}\t{producto.Precio}\t{producto.StockActual}\t{producto.StockMinimo}\t{producto.CantidadVentas}");
            }

            Console.ReadKey();
        }

        private void RegistrarVendedor()
        {
            Console.Clear();
            Console.WriteLine("=== REGISTRAR NUEVO VENDEDOR ===");

            try
            {
                string codigo;
                do
                {
                    Console.Write("Código del vendedor (3 dígitos): ");
                    codigo = Console.ReadLine();
                    if (!Validaciones.ValidarCodigo(codigo))
                        Console.WriteLine("El código debe tener exactamente 3 dígitos.");
                    else if (vendedores.ContainsKey(codigo))
                        Console.WriteLine("Ya existe un vendedor con ese código.");
                } while (!Validaciones.ValidarCodigo(codigo) || vendedores.ContainsKey(codigo));

                string nombre;
                do
                {
                    Console.Write("Nombre del vendedor (2-50 caracteres): ");
                    nombre = Console.ReadLine();
                    if (!Validaciones.ValidarNombre(nombre))
                        Console.WriteLine("El nombre debe tener entre 2 y 50 caracteres.");
                } while (!Validaciones.ValidarNombre(nombre));

                Vendedor nuevoVendedor = new Vendedor(codigo, nombre);
                vendedores.Add(codigo, nuevoVendedor);

                Console.WriteLine("\n¡Vendedor registrado con éxito!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }

            Console.ReadKey();
        }

        private void BuscarVendedor()
        {
            Console.Clear();
            Console.WriteLine("=== BUSCAR VENDEDOR ===");

            string codigo;
            do
            {
                Console.Write("Ingrese el código del vendedor (3 dígitos): ");
                codigo = Console.ReadLine();
                if (!Validaciones.ValidarCodigo(codigo))
                    Console.WriteLine("El código debe tener exactamente 3 dígitos.");
            } while (!Validaciones.ValidarCodigo(codigo));

            if (vendedores.TryGetValue(codigo, out Vendedor vendedor))
            {
                Console.WriteLine("\n=== DETALLE DEL VENDEDOR ===");
                Console.WriteLine(vendedor);
            }
            else
            {
                Console.WriteLine("No se encontró ningún vendedor con ese código.");
            }

            Console.ReadKey();
        }

        private void DespedirVendedor()
        {
            Console.Clear();
            Console.WriteLine("=== DESPEDIR VENDEDOR ===");

            string codigo;
            do
            {
                Console.Write("Ingrese el código del vendedor (3 dígitos): ");
                codigo = Console.ReadLine();
                if (!Validaciones.ValidarCodigo(codigo))
                    Console.WriteLine("El código debe tener exactamente 3 dígitos.");
            } while (!Validaciones.ValidarCodigo(codigo));

            if (vendedores.TryGetValue(codigo, out Vendedor vendedor))
            {
                if (vendedor.Activo)
                {
                    vendedor.Despedir();
                    Console.WriteLine($"Vendedor {vendedor.Nombre} ha sido despedido.");
                }
                else
                {
                    Console.WriteLine("El vendedor ya está inactivo.");
                }
            }
            else
            {
                Console.WriteLine("No se encontró ningún vendedor con ese código.");
            }

            Console.ReadKey();
        }

        private void RecontratarVendedor()
        {
            Console.Clear();
            Console.WriteLine("=== RECONTRATAR VENDEDOR ===");

            string codigo;
            do
            {
                Console.Write("Ingrese el código del vendedor (3 dígitos): ");
                codigo = Console.ReadLine();
                if (!Validaciones.ValidarCodigo(codigo))
                    Console.WriteLine("El código debe tener exactamente 3 dígitos.");
            } while (!Validaciones.ValidarCodigo(codigo));

            if (vendedores.TryGetValue(codigo, out Vendedor vendedor))
            {
                if (!vendedor.Activo)
                {
                    vendedor.Recontratar();
                    Console.WriteLine($"Vendedor {vendedor.Nombre} ha sido recontratado.");
                }
                else
                {
                    Console.WriteLine("El vendedor ya está activo.");
                }
            }
            else
            {
                Console.WriteLine("No se encontró ningún vendedor con ese código.");
            }

            Console.ReadKey();
        }

        private void ListarVendedores()
        {
            Console.Clear();
            Console.WriteLine("=== LISTADO DE VENDEDORES ===");

            if (vendedores.Count == 0)
            {
                Console.WriteLine("No hay vendedores registrados.");
                Console.ReadKey();
                return;
            }

            foreach (var vendedor in vendedores.Values)
            {
                Console.WriteLine(vendedor);
            }

            Console.ReadKey();
        }

        private void ProcesarVenta()
        {
            Console.Clear();
            Console.WriteLine("=== PROCESAR VENTA ===");

            try
            {
                string codigoProducto;
                do
                {
                    Console.Write("Código del producto (3 dígitos): ");
                    codigoProducto = Console.ReadLine();
                    if (!Validaciones.ValidarCodigo(codigoProducto))
                        Console.WriteLine("El código debe tener exactamente 3 dígitos.");
                } while (!Validaciones.ValidarCodigo(codigoProducto));

                var producto = inventario.BuscarPorCodigo(codigoProducto);
                if (producto == null)
                {
                    Console.WriteLine("No se encontró ningún producto con ese código.");
                    Console.ReadKey();
                    return;
                }

                int cantidad;
                string inputCantidad;
                do
                {
                    Console.Write("Cantidad a vender: ");
                    inputCantidad = Console.ReadLine();
                    if (!Validaciones.ValidarStock(inputCantidad, out cantidad) || cantidad <= 0)
                        Console.WriteLine("Ingrese una cantidad válida (mayor a 0).");
                } while (!Validaciones.ValidarStock(inputCantidad, out cantidad) || cantidad <= 0);

                string codigoVendedor;
                do
                {
                    Console.Write("Código del vendedor (3 dígitos): ");
                    codigoVendedor = Console.ReadLine();
                    if (!Validaciones.ValidarCodigo(codigoVendedor))
                        Console.WriteLine("El código debe tener exactamente 3 dígitos.");
                } while (!Validaciones.ValidarCodigo(codigoVendedor));

                if (!vendedores.TryGetValue(codigoVendedor, out Vendedor vendedor))
                {
                    Console.WriteLine("No se encontró ningún vendedor con ese código.");
                    Console.ReadKey();
                    return;
                }

                if (!vendedor.Activo)
                {
                    Console.WriteLine("El vendedor está inactivo y no puede realizar ventas.");
                    Console.ReadKey();
                    return;
                }

                decimal total = producto.Precio * cantidad;

                // Registrar la venta
                producto.RegistrarVenta(cantidad);
                vendedor.RegistrarVentas(total);
                ventas.Add(new Ventas(codigoProducto, codigoVendedor, cantidad, total));

                // Mostrar factura
                Console.WriteLine("\n=== FACTURA ===");
                Console.WriteLine($"Producto: {producto.Nombre}");
                Console.WriteLine($"Código: {producto.Codigo}");
                Console.WriteLine($"Cantidad: {cantidad}");
                Console.WriteLine($"Precio unitario: {producto.Precio}");
                Console.WriteLine($"Total: {total:C}");
                Console.WriteLine($"Vendedor: {vendedor.Nombre} ({vendedor.Codigo})");
                Console.WriteLine($"Fecha: {DateTime.Now}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError al procesar la venta: {ex.Message}");
            }

            Console.ReadKey();
        }

        private void MostrarProductosMasVendidos()
        {
            Console.Clear();
            Console.WriteLine("=== PRODUCTOS MÁS VENDIDOS ===");

            var productos = inventario.ProductosMasVendidos();
            if (productos.Count == 0)
            {
                Console.WriteLine("No hay datos de ventas aún.");
                Console.ReadKey();
                return;
            }

            int totalVendido = inventario.TotalProductosVendidos();

            for (int i = 0; i < productos.Count; i++)
            {
                var producto = productos[i];
                double porcentaje = totalVendido > 0 ? (producto.CantidadVentas * 100.0 / totalVendido) : 0;
                Console.WriteLine($"{i + 1}. {producto.Nombre}: {porcentaje:F2}% ({producto.CantidadVentas} unidades)");
            }

            Console.ReadKey();
        }

        private void MostrarProductosMenosVendidos()
        {
            Console.Clear();
            Console.WriteLine("=== PRODUCTOS MENOS VENDIDOS ===");

            var productos = inventario.ProductosMenosVendidos();
            if (productos.Count == 0)
            {
                Console.WriteLine("No hay datos de ventas aún o todos los productos tienen 0 ventas.");
                Console.ReadKey();
                return;
            }

            int totalVendido = inventario.TotalProductosVendidos();

            for (int i = 0; i < productos.Count; i++)
            {
                var producto = productos[i];
                double porcentaje = totalVendido > 0 ? (producto.CantidadVentas * 100.0 / totalVendido) : 0;
                Console.WriteLine($"{i + 1}. {producto.Nombre}: {porcentaje:F2}% ({producto.CantidadVentas} unidades)");
            }

            Console.ReadKey();
        }

        private void MostrarProductosASurtir()
        {
            Console.Clear();
            Console.WriteLine("=== PRODUCTOS A SURTIR ===");

            var productos = inventario.ObtenerProductosASurtir();
            if (productos.Count == 0)
            {
                Console.WriteLine("No hay productos que necesiten ser surtidos.");
                Console.ReadKey();
                return;
            }

            foreach (var producto in productos)
            {
                int cantidadReponer = producto.StockMinimo * 2 - producto.StockActual;
                Console.WriteLine($"{producto.Nombre} (Stock actual: {producto.StockActual}, Mínimo: {producto.StockMinimo})");
                Console.WriteLine($"  Cantidad a reponer: {cantidadReponer}");
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        private void MostrarVendedoresPorDesempeno()
        {
            Console.Clear();
            Console.WriteLine("=== VENDEDORES POR DESEMPEÑO ===");

            if (vendedores.Count == 0)
            {
                Console.WriteLine("No hay vendedores registrados.");
                Console.ReadKey();
                return;
            }

            var vendedoresOrdenados = vendedores.Values
                .OrderByDescending(v => v.TotalVendido)
                .ToList();

            Console.WriteLine("Pos.\tCódigo\tNombre\t\tVentas\tTotal");
            for (int i = 0; i < vendedoresOrdenados.Count; i++)
            {
                var vendedor = vendedoresOrdenados[i];
                Console.WriteLine($"{i + 1}\t{vendedor.Codigo}\t{vendedor.Nombre}\t{vendedor.VentasRealizadas}\t{vendedor.TotalVendido:C}");
            }

            Console.ReadKey();


            #endregion
        }
    }
}
