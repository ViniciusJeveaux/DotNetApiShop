using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Shop.Models
{
    public class Category
    {
        [Key]
        public int Id {get; set;}

        
        [Required(ErrorMessage="Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage="Este campo deve contar entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage="Este campo deve contar entre 3 e 60 caracteres")]
        public string Title{get; set;}

    }
}