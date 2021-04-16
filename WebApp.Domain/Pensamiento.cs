using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Domain
{
    public class Pensamiento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [MaxLength(100, ErrorMessage = "El máximo es de 100 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Contenido { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Imagen { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [MaxLength(112, ErrorMessage = "El máximo es de 112 caracteres")]
        public string Autor { get; set; }
    }
}
