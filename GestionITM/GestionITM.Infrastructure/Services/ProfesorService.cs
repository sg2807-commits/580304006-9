using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using GestionITM.Domain.Entities;
using GestionITM.Domain.Interfaces;
using System.Collections.Generic;

namespace GestionITM.Infrastructure.Services
{
    public class ProfesorService : IProfesorService
    {
        private readonly IProfesorRepository _profesorRepository; // Acceso al repositorio

        public ProfesorService(IProfesorRepository profesorRepository)
        {
            _profesorRepository = profesorRepository; // Guardamos el repositorio
        }

        public async Task<IEnumerable<Profesor>> GetAllAsync()
        {
            return await _profesorRepository.GetAllAsync(); // Pedir datos al repositorio
        }

        public async Task AddAsync(Profesor profesor)
        {
            // VALIDACIÓN 1: Especialidad no puede ser vacía
            if (string.IsNullOrWhiteSpace(profesor.Especialidad))
            {
                throw new Exception("La especialidad no puede estar vacía");
            }

            // REGLA DEL TALLER: imprimir log solo si es Arquitectura
            if (profesor.Especialidad == "Arquitectura")
            {
                Console.WriteLine("Perfil Senior Detectado");
            }

            // ERROR INTENCIONAL PARA PROBAR MIDDLEWARE:
            if (profesor.Nombre == "Error")
            {
                throw new Exception("Error de prueba");
            }

            // Guardar en DB siempre
            await _profesorRepository.AddAsync(profesor);
        }
    }
}