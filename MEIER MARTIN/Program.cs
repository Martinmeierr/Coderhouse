using EjemploDeClase;
using PROYECTO_FINAL_C.Consultas;

namespace PROYECTO_FINAL_C
{
    public class ProbarObjetos
    {
        static void Main (string[] args)
        {
            InicioSesion inicioSesion = new InicioSesion();

            inicioSesion.GetUsuarios();

            ProductoHandler productoHandler = new ProductoHandler();

            productoHandler.GetProductos();


            ProductoVendidoHandler productoVendidoHandler = new ProductoVendidoHandler();

            productoVendidoHandler.GetProductoVendido();

            VentaHandler ventaHandler = new VentaHandler();

            ventaHandler.GetVenta();

            UsuarioHandler usuarioHandler = new UsuarioHandler();

            usuarioHandler.GetUsuarios();

        }
        
    }
}