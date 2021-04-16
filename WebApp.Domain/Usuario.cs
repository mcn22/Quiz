using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebApp.Domain;

namespace EditorialMvc.Models
{
    public class Usuario : IdentityUser
    {

        //public string Direccion { get; set; }

        //public string Canton { get; set; }

        //public string Provincia { get; set; }

        //public string CodigoPostal { get; set; }

        //[NotMapped]
        //public string Role { get; set; }

        //public int? CompaniaId { get; set; }


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

        [ForeignKey("PensamientoId")]
        public Pensamiento Pensamiento { get; set; }
        


        //[ForeignKey("CompaniaId")]
        //public Compania Compania { get; set; }
    }
}
