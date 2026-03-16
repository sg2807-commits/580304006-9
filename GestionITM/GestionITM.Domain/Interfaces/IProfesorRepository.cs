using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GestionITM.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionITM.Domain.Interfaces
{
    public interface IProfesorRepository
    {
        Task<IEnumerable<Profesor>> GetAllAsync(); // Para obtener todos los profesores

        Task AddAsync(Profesor profesor); // Agrega profesor
    }
}