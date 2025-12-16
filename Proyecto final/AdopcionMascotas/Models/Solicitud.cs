using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdopcionMascotas.Models
{
    [Table("SO_Solicitudes")]
    public class Solicitud
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Mascota")]
        public int IdMascota { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public int IdUsuario { get; set; }

        [Display(Name = "Fecha de Solicitud")]
        public DateTime FechaSolicitud { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [StringLength(500)]
        [Display(Name = "Comentarios")]
        [DataType(DataType.MultilineText)]
        public string Comentarios { get; set; }

        [StringLength(500)]
        [Display(Name = "Motivo de Rechazo")]
        [DataType(DataType.MultilineText)]
        public string MotivoRechazo { get; set; }

        [Display(Name = "Fecha de Respuesta")]
        public DateTime? FechaRespuesta { get; set; }

        // Propiedades de navegación
        [ForeignKey("IdMascota")]
        public virtual Mascota Mascota { get; set; }

        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; }
    }
}