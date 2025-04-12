using CadastroPessoaMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoaMVC.Data
{
    public class CadastroContext : DbContext
    {
        public CadastroContext(DbContextOptions<CadastroContext> options) : base(options) { }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}