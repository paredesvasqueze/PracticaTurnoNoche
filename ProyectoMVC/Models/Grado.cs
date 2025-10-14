using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Grado
    {
        [Key]
        [Required(ErrorMessage = "El IdGrado es obligatorio")]
        public int IdGrado { get; set; }

        [Required(ErrorMessage = "El IdColegio es obligatorio")]
        [ForeignKey("Colegio")]
        public int IdColegio { get; set; }

        [Required(ErrorMessage = "El nivel es obligatorio")]
        [StringLength(50, ErrorMessage = "El nivel no puede tener más de 50 caracteres")]
        public string Nivel { get; set; }

        [Required(ErrorMessage = "El nombre del grado es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre del grado no puede tener más de 50 caracteres")]
        public string NombreGrado { get; set; }

        [Required(ErrorMessage = "La sección es obligatoria")]
        [StringLength(10, ErrorMessage = "La sección no puede tener más de 10 caracteres")]
        public string Seccion { get; set; }

        [Required(ErrorMessage = "El tutor es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre del tutor no puede tener más de 100 caracteres")]
        public string Tutor { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        public bool Estado { get; set; }

    }
}
