using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace restaurant.Models
{
    public class Repartidor
    {
        [Column("id_categoria")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id_repartidor {get;set;}
        public string transporte {get;set;}
        public Usuario usuario {get;set;}
    }
}