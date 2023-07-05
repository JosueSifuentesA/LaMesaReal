using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace restaurant.Models
{
    [Table("categoriaproducto")]
    public class CategoriaProducto
    {
        [Column("id_categoria")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id_categoria {get;set;}

        [Required]
        [Column("nombre_categoria")]
        public string nombre_categoria {get;set;}

        public List<Producto> Producto { get; set; }

    }
}