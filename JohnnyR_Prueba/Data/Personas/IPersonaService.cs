using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JohnnyR_Prueba.Models;

namespace JohnnyR_Prueba.Data.Personas
{
    interface IPersonaService
    {
        Task<Persona> GetDetailsPersona(int id);
        Task<bool> InsertPersona(Persona persona);
        Task<bool> UpdatePersona(Persona persona);
        Task<bool> SavePersona(Persona persona);
        Task<bool> DeletePersona(int id);
    }
}