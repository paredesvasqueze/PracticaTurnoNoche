using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Alumno
    {
        public int IdAlumno { get; set; }            // PK
        public int IdColegio { get; set; }           // FK
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string DNI { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public char Genero { get; set; }              // 'M' o 'F'
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string? Email { get; set; }
        public bool Estado { get; set; }             

       
        public Colegio? Colegio { get; set; }
    }
}