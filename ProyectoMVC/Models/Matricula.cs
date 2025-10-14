using System;

namespace SistemaColegio.Models
{
    public class Matricula
    {
        public int IdMatricula { get; set; }   // PK
        public int IdAlumno { get; set; }      // FK
        public int IdGrado { get; set; }       // FK
        public DateTime FechaMatricula { get; set; }
        public int AñoLectivo { get; set; }
        public bool Estado { get; set; }       // true = activa, false = anulada
    }
}