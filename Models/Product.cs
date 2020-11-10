using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Shop.Models
{
    public class Product
    {
        [Key]
        public int Id {get; set;}

        
        [Required(ErrorMessage="Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage="Este campo deve contar entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage="Este campo deve contar entre 3 e 60 caracteres")]
        public string Title{get; set;}

        [MaxLength(1024, ErrorMessage="Este campo deve contar no maximo 1024 caracteres")]
        public string Description {get; set;}

        [Required(ErrorMessage="Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage="Este campo deve ser maior que zero")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price{get; set;}

        public int CategoryId{get; set;}

        public Category Category {get; set;}








    }
}