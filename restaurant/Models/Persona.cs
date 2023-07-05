using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace restaurant.Models
{
    [Table("persona")]
    public class Persona
    {



        [Column("id_persona")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id_persona {get;set;}
        public string nombre_persona {get;set;}
        public string apellidoPaterno_persona {get;set;}
        public string apellidoMaterno_persona {get;set;}
        public string telefono_persona {get;set;}
        public char sexo_persona {get;set;}

    }
}