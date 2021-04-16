using System;
using System.ComponentModel.DataAnnotations;

namespace EditorialMvc.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Categoría")]
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
    }
}