using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModeloValidaciones.Models
{
    public class Producto : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre no debe superar los 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Descripcion { get; set; }

        [Range(0.01, 9999.99, ErrorMessage = "El precio debe ser mayor que 0")]
        public decimal Precio { get; set; }

        [Range(0, 1000, ErrorMessage = "El stock debe estar entre 0 y 1000 unidades")]
        public int Stock { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Vencimiento")]
        public DateTime? FechaVencimiento { get; set; }

        [Range(0, 100, ErrorMessage = "El descuento debe estar entre 0% y 100%")]
        [Display(Name = "Descuento (%)")]
        public int? Descuento { get; set; }

        // Validación cruzada:
        // - Si el stock es menor a 10, el descuento no puede superar 20%
        // - Si se ingresa FechaVencimiento, debe ser estrictamente posterior a la fecha actual
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Stock < 10 && Descuento.HasValue && Descuento.Value > 20)
            {
                yield return new ValidationResult(
                    "Si el stock es menor a 10, el descuento no puede superar el 20%",
                    new[] { nameof(Descuento) });
            }

            if (FechaVencimiento.HasValue)
            {
                // Comparar solo la parte fecha (sin hora)
                var fecha = FechaVencimiento.Value.Date;
                var hoy = DateTime.Today;
                if (fecha <= hoy)
                {
                    yield return new ValidationResult(
                        "La fecha de vencimiento, si se especifica, debe ser mayor que la fecha actual",
                        new[] { nameof(FechaVencimiento) });
                }
            }

            yield break;
        }
    }
}
