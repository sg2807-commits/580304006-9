// ARCHIVO: MappingProfile.cs

using AutoMapper;
using GestionITM.Domain.Dtos;
using GestionITM.Domain.Entities;

namespace GestionITM.API.Mappings
{
    // Configura los mapeos entre entidades y DTOs
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ============================================
            // ESTUDIANTE
            // ============================================

            CreateMap<Estudiante, EstudianteDto>();

            CreateMap<EstudianteCreateDto, Estudiante>();

            // ============================================
            // PROFESOR
            // ============================================

            CreateMap<Profesor, ProfesorDto>();

            CreateMap<ProfesorCreateDto, Profesor>();

            // ============================================
            // MATRÍCULA
            // ============================================

            CreateMap<Matricula, MatriculaDto>()
                .ForMember(
                    dest => dest.NombreEstudiante,
                    opt => opt.MapFrom(src => src.Estudiante!.Nombre)
                )
                .ForMember(
                    dest => dest.NombreCurso,
                    opt => opt.MapFrom(src => src.Curso!.Nombre)
                );

            CreateMap<MatriculaCreateDto, Matricula>();
        }
    }
}