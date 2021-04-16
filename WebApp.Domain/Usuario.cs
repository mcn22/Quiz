using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EditorialMvc.Models
{
    public class Usuario : IdentityUser
    {
        [Required]
        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Canton { get; set; }

        public string Provincia { get; set; }

        public string CodigoPostal { get; set; }

        [NotMapped]
        public string Role { get; set; }

        public int? CompaniaId { get; set; }

        //[ForeignKey("CompaniaId")]
        //public Compania Compania { get; set; }
    }
}
