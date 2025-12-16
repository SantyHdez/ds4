using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdopcionMascotas.Models
{
    [Table("SO_Refugios")]
    public class Refugio
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del refugio es obligatorio")]
        [StringLength(100)]
        [Display(Name = "Nombre del Refugio")]
        public string Nombre { get; set; }

        [StringLength(200)]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [StringLength(20)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [StringLength(100)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Fecha de Registro")]
        public DateTime FechaRegistro { get; set; }
    }
}