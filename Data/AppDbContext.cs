using Microsoft.EntityFrameworkCore;
using GameStoreMVC.Models;

namespace GameStoreMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });

            // Seed de um admin padrão (senha: admin123)
            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 1,
                Nome = "Administrador",
                Email = "admin@gamestore.com",
                Senha = BCrypt.Net.BCrypt.HashPassword("admin123"),
                Role = "Admin",
                DataCriacao = new DateTime(2026, 1, 1)
            });

            // Seed de games de exemplo
            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    Id = 1,
                    Titulo = "Mario Bros Dev",
                    Descricao = "O clássico jogo de plataforma que marcou gerações.",
                    Preco = 2500.00m,
                    ImagemUrl = "https://placehold.co/400x300/1a1a2e/16213e?text=Mario+Bros",
                    Categoria = "Aventura",
                    DataCadastro = new DateTime(2026, 1, 1)
                },
                new Game
                {
                    Id = 2,
                    Titulo = "Zelda: Realm of Shadows",
                    Descricao = "Embarque em uma aventura épica pelo reino de Hyrule.",
                    Preco = 3500.00m,
                    ImagemUrl = "https://placehold.co/400x300/0f3460/16213e?text=Zelda",
                    Categoria = "RPG",
                    DataCadastro = new DateTime(2026, 1, 1)
                },
                new Game
                {
                    Id = 3,
                    Titulo = "Speed Racers GT",
                    Descricao = "Acelere nas pistas mais radicais do mundo.",
                    Preco = 1800.00m,
                    ImagemUrl = "https://placehold.co/400x300/533483/16213e?text=Speed+Racers",
                    Categoria = "Corrida",
                    DataCadastro = new DateTime(2026, 1, 1)
                }
            );
        }
    }
}
