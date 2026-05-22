using Xunit;
using Moq;
using AutoMapper;
using GestionITM.Domain.Interfaces;
using GestionITM.Infrastructure.Services;
using GestionITM.Domain.Dtos;
using GestionITM.Domain.Entities;

namespace GestionITM.Tests
{
    public class MatriculaServiceTests
    {
        [Fact]
        public async Task CreateAsync_CursoSinCupos_DebeLanzarExcepcion()
        {
            // ============================================
            // ARRANGE
            // ============================================

            var mockRepository = new Mock<IMatriculaRepository>();
            var mockMapper = new Mock<IMapper>();

            // ESTO <--- estudiante falso
            mockRepository
                .Setup(r => r.ObtenerEstudiantePorIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new Estudiante());

            // ESTO <--- curso SIN cupos
            mockRepository
                .Setup(r => r.ObtenerCursoPorIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new Curso
                {
                    CuposDisponibles = 0
                });

            var service = new MatriculaService(
                mockRepository.Object,
                mockMapper.Object);

            var dto = new MatriculaCreateDto
            {
                EstudianteId = 1,
                CursoId = 1,
                Periodo = "2026-1"
            };

            // ============================================
            // ACT + ASSERT
            // ============================================

            var exception = await Assert.ThrowsAsync<Exception>(() =>
                service.CreateAsync(dto));

            Assert.Equal(
                "No hay cupos disponibles para este curso.",
                exception.Message);
        }
    }
}