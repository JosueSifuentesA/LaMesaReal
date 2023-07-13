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

        public async Task<List<Producto>> BuscarProductos()
        {
            var productos = await _context.DataProducto.ToListAsync();
            //var productos = from p in _context.DataProducto select p;
            return productos;
        }
    
        public async Task<List<Producto>> BuscarProductos(int categoria){
            var productos =  await _context.DataProducto.Where(prod => prod.categoriaProductoId == categoria).ToListAsync();
            return productos;
        }

        public async Task<List<Producto>> BuscarProductos(string nombre){
            var producto = await _context.DataProducto.Where(prod=>prod.nombre_producto==nombre).ToListAsync();
            return  producto;
        }

        public async Task<List<Producto>> BuscarProductos(string nombre,int categoria){
            var producto =  await _context.DataProducto.Where(prod=>prod.nombre_producto==nombre && prod.categoriaProductoId==categoria).ToListAsync();
            return producto;
        }

        public async Task CrearProducto(string nombre_producto, double precio_producto, string descripcion_producto, string url_image, int categoriaProductoId,byte[] imgSubidaByte)
        {
            var producto = new Producto {
                nombre_producto = nombre_producto,
                precio_producto = precio_producto,
                descripcion_producto = descripcion_producto,
                url_image = url_image,
                categoriaProductoId = categoriaProductoId,
                imgSubidaByte=imgSubidaByte
            };

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