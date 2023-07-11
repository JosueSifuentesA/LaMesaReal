using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using restaurant.Models;
using restaurant.Data;

namespace restaurant.Services
{
    public class CategoriaServiceImplement : ICategoriaSevice
    {

        private readonly ApplicationDbContext _context;

        public CategoriaServiceImplement(ApplicationDbContext context){
            _context = context;
        }

        public async Task AñadirCategoria(string nombreCategoria)
        {
            var categoria = new CategoriaProducto {nombre_categoria = nombreCategoria}; 
            await _context.DataCategoriaProducto.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task EditarCategoria(int id,string nombreCategoria)
        {
            var categoria = await _context.DataCategoriaProducto.FindAsync(id);
            if(categoria != null){
                categoria.nombre_categoria = nombreCategoria;
                await _context.SaveChangesAsync();
            }else{
                Console.WriteLine("No se encontro la Categoria");
            }

        }

        public async Task EliminarCategoria(int id)
        {
            var categoria = await _context.DataCategoriaProducto.FindAsync(id);
            if(categoria != null){
                _context.DataCategoriaProducto.Remove(categoria);
                await _context.SaveChangesAsync();
            }else{
                Console.WriteLine("No se encontro la categoria a eliminar");
            }

        }

        public IEnumerable<CategoriaProducto> ListarCategorias()
        {
            IEnumerable<CategoriaProducto> categorias = _context.DataCategoriaProducto;
            return _context.DataCategoriaProducto;
        }

        public async Task<CategoriaProducto> ObtenerCategoriaPorIdAsync(int id)
{
        CategoriaProducto categoria = await _context.DataCategoriaProducto.FindAsync(id);
        if (categoria != null)
        {
            return categoria;
        }
        else
        {
            Console.WriteLine("No se encontró la categoría");
            throw new Exception("No se encontró la categoría");
        }
    }

    }
}