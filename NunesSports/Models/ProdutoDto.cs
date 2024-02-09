using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace NunesSports.Models
{
    public class ProdutoDto
    {
        [Required, MaxLength(100)]
        public string Nome { get; set; } = "";
        [Required, MaxLength(60)]
        public string Categoria { get; set; } = "";
        [Required]
        public string Descricao { get; set; } = "";
        [Required]
        public decimal Preco { get; set; }
        
        public IFormFile? Imagem { get; set; }
    }
}
