using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Domain;

namespace Domain
{
    public class Usuario : IdentityUser
    {

        [Required(ErrorMessage = "Este campo es requerido.")]
        [MaxLength(56, ErrorMessage = "El máximo es de 56 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [MaxLength(56, ErrorMessage = "El máximo es de 56 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [MaxLength(56, ErrorMessage = "El máximo es de 56 caracteres")]
        public string Telefono { get; set; }

        [NotMapped]
        public string Rol { get; set; }

        public int? PensamientoId { get; set; }

        [ForeignKey("HotelId")]
        public Pensamiento Pensamiento { get; set; }
    }
}
