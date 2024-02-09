using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;


namespace NunesSports.Models
{
    public class Produto
    {
        [MaxLength(250)]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Nome { get; set; } = "";
        [MaxLength(60)]
        public string Categoria { get; set; } = "";
        public string Descricao { get; set; } = "";
        [Precision(16, 2)]
        public decimal Preco { get; set; }
        [MaxLength(100)] 
        public string NomeImagem { get; set; } = "";
        public DateTime CriadoEm {  get; set; }

    }
}
