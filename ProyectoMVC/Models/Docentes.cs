using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Docentes
    {
        [Required(ErrorMessage = "El Id del docente es obligatorio")]
        public int IdDocente { get; set; }

        [Required(ErrorMessage = "El Id del colegio es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un colegio válido")]
        public int IdColegio { get; set; }

        [Required(ErrorMessage = "Los nombres son obligatorios")]
        [StringLength(80, ErrorMessage = "Los nombres no pueden tener más de 80 caracteres")]
        [RegularExpression(@"^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]+$", ErrorMessage = "Los nombres solo pueden contener letras")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        [StringLength(80, ErrorMessage = "Los apellidos no pueden tener más de 80 caracteres")]
        [RegularExpression(@"^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]+$", ErrorMessage = "Los apellidos solo pueden contener letras")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El DNI es obligatorio")]
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "El DNI debe tener exactamente 8 dígitos numéricos")]
        public string DNI { get; set; }

        [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
        [StringLength(80, ErrorMessage = "El correo electrónico no puede tener más de 80 caracteres")]
        public string Email { get; set; }

        [RegularExpression(@"^9[0-9]{8}$", ErrorMessage = "El teléfono debe tener 9 dígitos y empezar con 9")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "El teléfono debe tener exactamente 9 dígitos")]
        public string Telefono { get; set; }

        [StringLength(100, ErrorMessage = "La especialidad no puede tener más de 100 caracteres")]
        [RegularExpression(@"^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]+$", ErrorMessage = "La especialidad solo puede contener letras")]
        public string Especialidad { get; set; }

        [Required(ErrorMessage = "La fecha de ingreso es obligatoria")]
        [DataType(DataType.Date, ErrorMessage = "La fecha de ingreso no es válida")]
        public DateTime FechaIngreso { get; set; }

        [Required(ErrorMessage = "Debe indicar el estado del docente")]
        public bool Estado { get; set; }
    }
}
