using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GestionITM.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionITM.Domain.Interfaces // Define qué puede hacer el servicio, pero NO cómo
{
    public interface IProfesorService
    {
        Task<IEnumerable<Profesor>> GetAllAsync(); // Obtener todos los profesores
        Task AddAsync(Profesor profesor); // Registrar profesor
        Task<Profesor> GetByIdAsync(int id);
    }
}
