using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NunesSports.Models;
using NunesSports.Services;

namespace NunesSports.Pages.Admin.Produtos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public List<Produto> Produtos { get; set; } = new List<Produto>();
        public IndexModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            Produtos = context.Produtos.OrderByDescending(p =>p.Id).ToList();
        }
    }
}
