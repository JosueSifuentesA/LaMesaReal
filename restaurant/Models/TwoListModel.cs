using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurant.Models
{
    public class TwoListModel
    {
        public List<Producto> listProducto {get;set;}
        public List<CategoriaProducto> listCategoria {get;set;}
    }
}