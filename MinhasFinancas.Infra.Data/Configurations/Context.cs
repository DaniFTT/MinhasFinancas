using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Infra.Data.Configurations
{
    public class Context : IdentityDbContext<User>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
        public DbSet<Movement> Movement { get; set; }
        public DbSet<Wallet> Wallet { get; set; }
        public DbSet<User> User { get; set; }

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
            builder.Entity<User>().ToTable("AspNetUsers").HasKey(t => t.Id);

            builder.Entity<User>()
                .HasOne(b => b.Wallet)
                .WithOne(i => i.User)
                .HasForeignKey<Wallet>(b => b.UserId);

            builder.Entity<User>()
                .HasMany(b => b.Categories)
                .WithOne(i => i.User)
                .HasForeignKey(b => b.UserId);

            builder.Entity<User>()
                .HasMany(b => b.Movements)
                .WithOne(i => i.User)
                .HasForeignKey(b => b.UserId);

            builder.Entity<PaymentMethod>()
                .HasOne(b => b.Wallet)
                .WithMany(i => i.PaymentMethods)
                .HasForeignKey(b => b.WalletId);

            builder.Entity<PaymentMethod>()
                .HasMany(b => b.Movements)
                .WithOne(i => i.PaymentMethod);

            builder.Entity<Movement>()
                .HasMany(p => p.Categories)
                .WithMany(p => p.Movements)
                .UsingEntity(j => j.ToTable("MovementCategories"));


            base.OnModelCreating(builder);
        }

        public string ObterStringDeConexao()
        {
            string strncon = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Minhas_Financas;Integrated Security=False;User ID=sa;Password=61403641;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            return strncon;
        }
    }
}
