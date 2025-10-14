using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Docentes
    {
        [Required(ErrorMessage = "El Id del docente es obligatorio")]
        public int IdDocente { get; set; }

        [Required(ErrorMessage = "El Id del colegio es obligatorio")]
        public int IdColegio { get; set; }

        [Required(ErrorMessage = "Los nombres son obligatorios")]
        [StringLength(80)]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        [StringLength(80)]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El DNI es obligatorio")]
        [StringLength(12)]
        public string DNI { get; set; }

        [EmailAddress(ErrorMessage = "El email no es válido")]
        [StringLength(80)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Telefono { get; set; }

        [StringLength(100)]
        public string Especialidad { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de ingreso es obligatoria")]
        public DateTime FechaIngreso { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}
