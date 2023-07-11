using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using restaurant.Models;

namespace restaurant.Services
{
    public interface ICategoriaSevice
    {
        
        
         IEnumerable<CategoriaProducto> ListarCategorias();
         Task AñadirCategoria(string nombreCategoria);
         Task EditarCategoria(int id,string nombreCategoria);
        Task<CategoriaProducto> ObtenerCategoriaPorIdAsync(int id);

         Task EliminarCategoria(int id);


    }
}