using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using restaurant.Models;

namespace restaurant.Services
{
    public interface IPersonaService
    {
        public Task CrearPersona(string nombre,string apellidoPaterno,string apellidoMaterno,char sexo,string telefono);
        public void EliminarPersonaPorId(int id);
        public void EditarPersona(int id);
        public Persona BuscarPersonaPorId(int id);
        public Persona BuscarPersonaPorDatos(string nombre,string apellidoPaterno,string apellidoMaterno);
    }
}