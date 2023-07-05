using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using restaurant.Models;
using restaurant.Data;

namespace restaurant.Services
{
    public class PersonaServiceImplement : IPersonaService
    {

        private readonly ApplicationDbContext _context;

        public PersonaServiceImplement(ApplicationDbContext context){
            _context = context;
        }

        public Persona BuscarPersonaPorDatos(string nombre, string apellidoPaterno, string apellidoMaterno)
        {
            throw new NotImplementedException();
        }

        public Persona BuscarPersonaPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task CrearPersona(string nombre, string apellidoPaterno, string apellidoMaterno, char sexo, string telefono)
        {
            var persona = new Persona {nombre_persona = nombre , apellidoMaterno_persona = apellidoMaterno ,apellidoPaterno_persona = apellidoPaterno,sexo_persona=sexo,telefono_persona=telefono};
            _context.DataPersona.Add(persona);
            await _context.SaveChangesAsync();
        }

        public void EditarPersona(int id)
        {
            throw new NotImplementedException();
        }

        public void EliminarPersonaPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}