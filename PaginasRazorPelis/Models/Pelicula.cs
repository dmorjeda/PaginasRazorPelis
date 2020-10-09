using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaginasRazorPelis.Models
{
    public class Pelicula
    {
        public int ID { get; set; }

        [StringLength(60, ErrorMessage = "Longitud erronea", MinimumLength = 3)]
        [Required]
        public string Titulo { get; set; }

        [Display(Name ="Fecha de Estreno")]
        [DataType(DataType.Date)]
        public DateTime FechaEstreno { get; set; }


        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [StringLength(60, ErrorMessage = "Longitud erronea")]
        [Display(Name = "Género")]
        public string Genero { get; set; }

        [Range(1,100)]
        [DataType(DataType.Currency)]
        [Column(TypeName ="decimal(18,2)")]

        public decimal Precio { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z0-9""'\s-]*$")]
        public string Rating { get; set; }
        

        
    }
}
