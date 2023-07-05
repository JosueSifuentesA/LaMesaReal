using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace restaurant.Models
{
    [Table("tarjeta")]
    public class Tarjeta
    {
        [Column("id_categoria")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string numero_tarjeta {get;set;}
        public char categoria_tarjeta {get;set;}
        public Usuario usuario {get;set;}
    }
}