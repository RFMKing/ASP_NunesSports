using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NunesSports.Models;
using NunesSports.Services;
using System.Globalization;

namespace NunesSports.Pages.Admin.Produtos
{
    public class CriarModel : PageModel
    {
        private readonly IWebHostEnvironment enviroment;
        private readonly ApplicationDbContext context;

        [BindProperty]
        public ProdutoDto ProdutoDto { get; set; } = new ProdutoDto();

        public CriarModel(IWebHostEnvironment enviroment, ApplicationDbContext context)
        {
            this.enviroment = enviroment;
            this.context = context;
        }
        public void OnGet()
        {
        }

        public string errorMessage = "";
        public string successMessage = "";
        public void OnPost()
        {
            NumberFormatInfo mNumberFormatInfo = new CultureInfo("en-US", false).NumberFormat;

            if (ProdutoDto.Imagem == null)
            {
                ModelState.AddModelError("ProdutoDto.Imagem", "o arquivo de imagem é requerido");
            }
            if (!ModelState.IsValid)
            {
                errorMessage = "Preencha todos os campos";
                return;
            }

            //salvar a imagem
            //string valorBR = ProdutoDto.Preco.ToString("C", mNumberFormatInfo);
            //decimal valorEng = decimal.Parse(valorBR, System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
            string nomeImagem = Path.GetFileName(ProdutoDto.Imagem!.FileName);
            string imageFullPath = enviroment.WebRootPath + "/img/" + nomeImagem;
            using(var stream = System.IO.File.Create(imageFullPath)) 
            {
                ProdutoDto.Imagem.CopyTo(stream);
            }
            //salvar o produto na basede dados

            Produto produto = new Produto()
            {
                Nome = ProdutoDto.Nome,
                Categoria = ProdutoDto.Categoria,
                Descricao = ProdutoDto.Descricao ?? "",
                Preco = ProdutoDto.Preco,
                NomeImagem = nomeImagem,
                CriadoEm = DateTime.Now,
            };
            context.Produtos.Add(produto);
            context.SaveChanges();  

            //limpar o formulario
            ProdutoDto.Nome = "";
            ProdutoDto.Categoria = "";
            ProdutoDto.Descricao = "";
            ProdutoDto.Preco = 0;
            ProdutoDto.Imagem = null;


            ModelState.Clear();
            successMessage = "Cadastro feito com sucesso";

            Response.Redirect("/Admin/Produtos/Index");
        }
    }
}
