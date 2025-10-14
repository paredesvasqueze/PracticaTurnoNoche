using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AlumnoRepository : IAlumnoRepository
    {
        private readonly List<Alumno> _alumnos = new();

        public Task<IEnumerable<Alumno>> GetAllAsync() =>
            Task.FromResult(_alumnos.AsEnumerable());

        public Task<Alumno?> GetByIdAsync(int id) =>
            Task.FromResult(_alumnos.FirstOrDefault(a => a.IdAlumno == id));

        public Task AddAsync(Alumno alumno)
        {
            alumno.IdAlumno = _alumnos.Count + 1;
            _alumnos.Add(alumno);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Alumno alumno)
        {
            var existente = _alumnos.FirstOrDefault(a => a.IdAlumno == alumno.IdAlumno);
            if (existente != null)
            {
                existente.Nombres = alumno.Nombres;
                existente.Apellidos = alumno.Apellidos;
                existente.DNI = alumno.DNI;
                existente.FechaNacimiento = alumno.FechaNacimiento;
                existente.Genero = alumno.Genero;
                existente.Direccion = alumno.Direccion;
                existente.Telefono = alumno.Telefono;
                existente.Email = alumno.Email;
                existente.Estado = alumno.Estado;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var alumno = _alumnos.FirstOrDefault(a => a.IdAlumno == id);
            if (alumno != null)
                _alumnos.Remove(alumno);

            return Task.CompletedTask;
        }
    }
}