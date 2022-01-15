using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Domain.Entities;

namespace MinhasFinancas.Infra.Data.Configurations
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
        public DbSet<Movement> Movement { get; set; }
        public DbSet<Wallet> Wallet { get; set; }
        public DbSet<ApplicationUser> User { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringDeConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            base.OnModelCreating(builder);
        }

        public string ObterStringDeConexao()
        {
            string strncon = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Minhas_Financas;Integrated Security=False;User ID=sa;Password=61403641;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            return strncon;
        }
    }
}
