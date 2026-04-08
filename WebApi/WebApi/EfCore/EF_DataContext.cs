using Microsoft.EntityFrameworkCore;

namespace WebApi.EfCore
{
    public class EF_DataContext : DbContext
    {
        public EF_DataContext(DbContextOptions<EF_DataContext> options) : base(options) { }

        // Tablas principales
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Categorías
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Mobile", Description = "Smartphones and futuristic mobile devices" },
                new Category { Id = 2, Name = "Laptop", Description = "Laptops and portable computers" }
            );

            // Productos
            modelBuilder.Entity<Product>().HasData(
                // Mobiles
                new Product { Id = 1, Name = "Futuristic Smartphone 1", Sku = "aaa001", Price = 1000, ImageUrl = "/img/1mobil.webp", CategoryId = 1 },
                new Product { Id = 2, Name = "Futuristic Smartphone 2", Sku = "aaa002", Price = 1000, ImageUrl = "/img/2mobil.webp", CategoryId = 1 },
                new Product { Id = 3, Name = "Futuristic Smartphone 3", Sku = "aaa003", Price = 1000, ImageUrl = "/img/3mobil.webp", CategoryId = 1 },
                new Product { Id = 4, Name = "Futuristic Smartphone 4", Sku = "aaa004", Price = 1000, ImageUrl = "/img/4mobil.webp", CategoryId = 1 },
                new Product { Id = 5, Name = "Futuristic Smartphone 5", Sku = "aaa005", Price = 1000, ImageUrl = "/img/5mobil.webp", CategoryId = 1 },
                new Product { Id = 6, Name = "Futuristic Smartphone 6", Sku = "aaa006", Price = 1000, ImageUrl = "/img/6mobil.webp", CategoryId = 1 },
                new Product { Id = 7, Name = "Futuristic Smartphone 7", Sku = "aaa007", Price = 1000, ImageUrl = "/img/7mobil.webp", CategoryId = 1 },
                new Product { Id = 8, Name = "Futuristic Smartphone 8", Sku = "aaa008", Price = 1000, ImageUrl = "/img/8mobil.webp", CategoryId = 1 },
                new Product { Id = 9, Name = "Futuristic Smartphone 9", Sku = "aaa009", Price = 1000, ImageUrl = "/img/9mobil.webp", CategoryId = 1 },
                new Product { Id = 10, Name = "Futuristic Smartphone 10", Sku = "aaa010", Price = 1000, ImageUrl = "/img/10mobil.webp", CategoryId = 1 },

                // Laptops
                new Product { Id = 11, Name = "Gaming Laptop 1", Sku = "bbb001", Price = 2000, ImageUrl = "/img/1laptop.webp", CategoryId = 2 },
                new Product { Id = 12, Name = "Gaming Laptop 2", Sku = "bbb002", Price = 2000, ImageUrl = "/img/2laptop.webp", CategoryId = 2 },
                new Product { Id = 13, Name = "Gaming Laptop 3", Sku = "bbb003", Price = 2000, ImageUrl = "/img/3laptop.webp", CategoryId = 2 },
                new Product { Id = 14, Name = "Gaming Laptop 4", Sku = "bbb004", Price = 2000, ImageUrl = "/img/4laptop.webp", CategoryId = 2 },
                new Product { Id = 15, Name = "Gaming Laptop 5", Sku = "bbb005", Price = 2000, ImageUrl = "/img/5laptop.webp", CategoryId = 2 },
                new Product { Id = 16, Name = "Gaming Laptop 6", Sku = "bbb006", Price = 2000, ImageUrl = "/img/6laptop.webp", CategoryId = 2 },
                new Product { Id = 17, Name = "Gaming Laptop 7", Sku = "bbb007", Price = 2000, ImageUrl = "/img/7laptop.webp", CategoryId = 2 },
                new Product { Id = 18, Name = "Gaming Laptop 8", Sku = "bbb008", Price = 2000, ImageUrl = "/img/8laptop.webp", CategoryId = 2 },
                new Product { Id = 19, Name = "Gaming Laptop 9", Sku = "bbb009", Price = 2000, ImageUrl = "/img/9laptop.webp", CategoryId = 2 },
                new Product { Id = 20, Name = "Gaming Laptop 10", Sku = "bbb010", Price = 2000, ImageUrl = "/img/10laptop.webp", CategoryId = 2 },
                new Product { Id = 21, Name = "Gaming Laptop 11", Sku = "bbb011", Price = 2000, ImageUrl = "/img/11laptop.webp", CategoryId = 2 },
                new Product { Id = 22, Name = "Gaming Laptop 12", Sku = "bbb012", Price = 2000, ImageUrl = "/img/12laptop.webp", CategoryId = 2 },
                new Product { Id = 23, Name = "Gaming Laptop 13", Sku = "bbb013", Price = 2000, ImageUrl = "/img/13laptop.webp", CategoryId = 2 }
            );
        }
    }
}