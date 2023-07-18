using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurant.Models
{
    public class ListAndModel<L,M>
    {
        public List<L> MiLista { get; set; }
        public M MiModelo { get; set; }

    }
}