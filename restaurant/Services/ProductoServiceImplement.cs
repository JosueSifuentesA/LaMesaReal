using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using restaurant.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

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
    
        public async Task<Producto> BuscarProductosPorId(int id){
            
            try{
                var producto = await _context.DataProducto.FindAsync(id);
                return producto;

            }catch(Exception e){
                Console.WriteLine(e);
                return null;
            }
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

        public async Task EditarProducto(int id,string nombre_producto,double precio_producto,string descripcion_producto,string url_image,int categoriaProductoId,UploadImgModel imgModel)
        {
            var producto = await _context.DataProducto.FindAsync(id);

            using(var ms = new MemoryStream()){

                if(imgModel != null && imgModel.imgSubida != null){
                    await imgModel.imgSubida.CopyToAsync(ms);
                    var imgSubidaByte = ms.ToArray();
                    producto.nombre_producto = nombre_producto;
                    producto.descripcion_producto = descripcion_producto;
                    producto.categoriaProductoId = categoriaProductoId;
                    producto.precio_producto = precio_producto;
                    producto.url_image = url_image;
                    producto.imgSubidaByte=imgSubidaByte;
                    await _context.SaveChangesAsync();
                
                }else{
                    Console.WriteLine("Error , no se encontro la imagen");
                }

            }

        }

        public async Task EliminarProducto(int id)
        {
            var producto = await _context.DataProducto.FindAsync(id);
            if(producto != null){
                _context.DataProducto.Remove(producto);
                await _context.SaveChangesAsync();
            }else{
                Console.WriteLine("No se encontro dicho producto a eliminar");
            }
        }

    }
}