using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NunesSports.Models;
using NunesSports.Services;

namespace NunesSports.Pages.Admin.Produtos
{
    public class EditarModel : PageModel
    {
        private readonly IWebHostEnvironment enviroment;
        private readonly ApplicationDbContext context;

        [BindProperty]
        public ProdutoDto ProdutoDto { get; set; } = new ProdutoDto();

        public Produto Produto { get; set; } = new Produto();

        public string errorMessage = "";
        public string successMessage = "";

        public EditarModel(IWebHostEnvironment enviroment, ApplicationDbContext context) 
        {
            this.enviroment = enviroment;
            this.context = context;
        }
        public void OnGet(int? id)
        {
            if(id == null)
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

            ProdutoDto.Nome = produto.Nome;
            ProdutoDto.Categoria= produto.Categoria;
            ProdutoDto.Descricao= produto.Descricao;
            ProdutoDto.Preco= produto.Preco;

            Produto = produto;
        }

        public void OnPost(int? id) 
        {
            if(id == null) 
            {
                Response.Redirect("/Admin/Produtos/Index");
                return;
            }

            if(!ModelState.IsValid) 
            {
                errorMessage= "Preencha todos os campos";
                return;
            }

            var produto = context.Produtos.Find(id);
            if(produto == null) 
            {
                Response.Redirect("/Admin/Produtos/Index");
                return;
            }

            //update do arquivo de imagem se houver nova imagem
            string newFilename = produto.NomeImagem;
            if(ProdutoDto.Imagem != null)
            {
                newFilename = Path.GetFileName(ProdutoDto.Imagem.FileName);

                string imageFullPath = enviroment.WebRootPath + "/img/" + newFilename;
                using (var stream = System.IO.File.Create(imageFullPath))
                {
                    ProdutoDto.Imagem.CopyTo(stream);
                }
                
                //deletando a aimagem antiga
                string oldImageFullPath = enviroment.WebRootPath + "/img/" + produto.NomeImagem;
                System.IO.File.Delete(oldImageFullPath);

            }
            //update do produto no bnaco de dados
            produto.Nome = ProdutoDto.Nome;
            produto.Categoria = ProdutoDto.Categoria;
            produto.Descricao = ProdutoDto.Descricao ?? "";
            produto.Preco = ProdutoDto.Preco;
            produto.NomeImagem = newFilename;

            context.SaveChanges();



            Produto = produto;
            successMessage = "Update do produto foi realizado";

            Response.Redirect("/Admin/Produtos/Index");
        }
    }
}
