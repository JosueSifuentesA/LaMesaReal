using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using restaurant.Models;
using Microsoft.EntityFrameworkCore;

using restaurant.Data;

namespace restaurant.Services
{
    public class ProductoServiceImplement : IProductoService
    {

        private readonly ApplicationDbContext _context;

        public ProductoServiceImplement(ApplicationDbContext context){
            _context = context;
        }

        public IEnumerable<Producto> BuscarProductos()
        {
            var productos = from p in _context.DataProducto select p;
            return productos;
        }

        public async Task CrearProducto(string nombre_producto, double precio_producto, string descripcion_producto, string url_image, int categoriaProductoId)
        {
            var producto = new Producto {nombre_producto = nombre_producto , precio_producto = precio_producto, descripcion_producto = descripcion_producto,url_image = url_image,categoriaProductoId = categoriaProductoId };

            await _context.DataProducto.AddAsync(producto);
            await _context.SaveChangesAsync();

        }

        public async Task EditarProducto(int id,string nombre_producto,double precio_producto,string descripcion_producto,string url_image,int categoriaProductoId)
        {
            var producto = await _context.DataProducto.FindAsync(id);
            producto.nombre_producto = nombre_producto;
            producto.descripcion_producto = descripcion_producto;
            producto.categoriaProductoId = categoriaProductoId;
            producto.precio_producto = precio_producto;
            producto.url_image = url_image;

            await _context.SaveChangesAsync();

        }

        public Task EliminarProducto(int id)
        {
            throw new NotImplementedException();
        }
    }
}