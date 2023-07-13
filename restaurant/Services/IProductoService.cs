using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using restaurant.Models;

namespace restaurant.Services
{
    public interface IProductoService
    {
        public Task<List<Producto>> BuscarProductos();

        public Task<List<Producto>> BuscarProductos(int categoria);

        public Task<List<Producto>> BuscarProductos(string nombre);
        public Task<List<Producto>> BuscarProductos(string nombre,int categoria);
        public Task CrearProducto(string nombre_producto,double precio_producto,string descripcion_producto,string url_image,int categoriaProducto,byte[] imgSubidaByte);

        public  Task EliminarProducto(int id);

        public  Task EditarProducto(int id,string nombre_producto,double precio_producto,string descripcion_producto,string url_image,int categoriaProductoId);

    }
}