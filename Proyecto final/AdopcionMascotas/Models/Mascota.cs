using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdopcionMascotas.Models
{
    [Table("SO_Mascotas")]
    public class Mascota
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La especie es obligatoria")]
        [StringLength(20)]
        [Display(Name = "Especie")]
        public string Especie { get; set; }

        [StringLength(50)]
        [Display(Name = "Raza")]
        public string Raza { get; set; }

        [Display(Name = "Edad (años)")]
        public int? Edad { get; set; }

        [StringLength(10)]
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [StringLength(20)]
        [Display(Name = "Tamaño")]
        public string Tamanio { get; set; }

        [StringLength(500)]
        [Display(Name = "Descripción")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        [StringLength(500)]
        [Display(Name = "URL de Foto")]
        [DataType(DataType.Url)]
        public string FotoUrl { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Display(Name = "Refugio")]
        public int? IdRefugio { get; set; }

        [Display(Name = "Fecha de Registro")]
        public DateTime FechaRegistro { get; set; }

        // Propiedad de navegación
        [ForeignKey("IdRefugio")]
        public virtual Refugio Refugio { get; set; }
    }
}