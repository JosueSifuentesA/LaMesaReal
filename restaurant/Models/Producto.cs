using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace restaurant.Models
{
    [Table("producto")]
    public class Producto
    {
        [Column("id_producto")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id_producto {get;set;}
        
        [Required]
        [Column("nombre_producto")]
        public string nombre_producto {get;set;}

        [Required]
        [Column("precio_producto")]
        public double precio_producto {get;set;}

        [Required]
        [Column("descripcion_producto")]
        public string descripcion_producto {get;set;}

        [Column("imagen_producto")]
        public string url_image {get;set;}

        public int categoriaProductoId { get; set; }
        public CategoriaProducto categoriaProducto { get; set; }

        public byte[]? imgSubidaByte {set;get;}

    }
}