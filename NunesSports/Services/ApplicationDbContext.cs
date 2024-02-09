using Microsoft.EntityFrameworkCore;
using NunesSports.Models;

namespace NunesSports.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Produto> Produtos { get; set; }
    }
}
