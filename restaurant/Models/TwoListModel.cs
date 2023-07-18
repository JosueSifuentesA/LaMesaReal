using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurant.Models
{
    public class TwoListModel<T,U>
    {
        public List<T> listProducto {get;set;}
        public List<U> listCategoria {get;set;}
    }
}