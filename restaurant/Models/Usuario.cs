using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace restaurant.Models
{
    [Table("usuario")]
    public class Usuario
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id_usuario")]
        public int id_usuario {get;set;}
        public string nombre_usuario {get;set;}
        public string contraseña_usuario {get;set;}
        [Column("rol_usuario")]
        public string rol_usuario {get;set;}
        public Persona persona {get;set;}
    }
}