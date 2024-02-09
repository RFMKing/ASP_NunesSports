using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NunesSports.Services;

namespace NunesSports.Pages.Admin.Produtos
{
    public class DeletarModel : PageModel
    {
        private readonly IWebHostEnvironment enviroment;
        private readonly ApplicationDbContext context;

        public DeletarModel(IWebHostEnvironment enviroment, ApplicationDbContext context)
        {
            this.enviroment = enviroment;
            this.context = context;
        }
        public void OnGet(int? id)
        {
            if (id == null) 
            {
                Response.Redirect("/Admin/Produtos/Index");
                return;
            }

            var produto = context.Produtos.Find(id);
            if(produto == null)
            {
                Response.Redirect("/Admin/Produtos/Index");
                return;
            }

            string imageFullPath = enviroment.WebRootPath + "/img/" + produto.NomeImagem;
            System.IO.File.Delete(imageFullPath);

            context.Produtos.Remove(produto);
            context.SaveChanges();

            Response.Redirect("/Admin/Produtos/Index");
        }
    }
}
