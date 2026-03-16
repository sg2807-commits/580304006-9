using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ARCHIVO: ProfesorRepository.cs

using GestionITM.Domain.Entities;
using GestionITM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionITM.Infrastructure.Repositories
{
    public class ProfesorRepository : IProfesorRepository
    {
        private readonly ApplicationDbContext _context; // Conecta con la DB

        public ProfesorRepository(ApplicationDbContext context)
        {
            _context = context; 
        }

        public async Task<IEnumerable<Profesor>> GetAllAsync()
        {
            return await _context.Profesores.ToListAsync(); // Trae a todos los profesores
        }

        public async Task AddAsync(Profesor profesor)
        {
            await _context.Profesores.AddAsync(profesor); // Agrega el profesor
            await _context.SaveChangesAsync(); // Gguarda cambios en la DB
        }
    }
}
