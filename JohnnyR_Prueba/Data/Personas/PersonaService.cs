using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JohnnyR_Prueba.Models;
using Microsoft.EntityFrameworkCore;

namespace JohnnyR_Prueba.Data.Personas
{
    public class PersonaService : IPersonaService
    {
        //Llamamos al Contexto de la DB para usarlo en los metodos del CRUD
        private readonly JohnnyRondon_PruebaContext _context;
        public PersonaService(JohnnyRondon_PruebaContext context)
        {
            _context = context;
        }
        public async Task<bool> DeletePersona(int id)
        {
            var persona = await _context.Persona.FindAsync(id);

            _context.Persona.Remove(persona);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Persona>> GetAllPersonas()
        {
            return await _context.Persona.ToListAsync();
        }

        public async Task<Persona> GetDetailsPersona(int id)
        {
            return await _context.Persona.FindAsync(id); 
        }

        public async Task<bool> InsertPersona(Persona persona)
        {
            _context.Persona.Add(persona);
            
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> SavePersona(Persona persona)
        {
            if (persona.Id > 0)
                return await UpdatePersona(persona);
            else
                return await InsertPersona(persona);
        }

        public async Task<bool> UpdatePersona(Persona persona)
        {
            _context.Entry(persona).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}