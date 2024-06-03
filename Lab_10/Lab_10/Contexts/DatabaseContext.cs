using Lab_10.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab_10.Contexts;

public class DatabaseContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductCategory> ProductsCategories { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }

    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<ProductCategory>()
        .HasKey(pc => new { pc.ProductId, pc.CategoryId });

    modelBuilder.Entity<ProductCategory>()
        .HasOne(pc => pc.Product)
        .WithMany(p => p.ProductsCategories)
        .HasForeignKey(pc => pc.ProductId);

    modelBuilder.Entity<ProductCategory>()
        .HasOne(pc => pc.Category)
        .WithMany(c => c.ProductsCategories)
        .HasForeignKey(pc => pc.CategoryId);

    modelBuilder.Entity<ShoppingCart>()
        .HasKey(sc => new { sc.AccountId, sc.ProductId });

    modelBuilder.Entity<ShoppingCart>()
        .HasOne(sc => sc.Account)
        .WithMany(a => a.ShoppingCarts)
        .HasForeignKey(sc => sc.AccountId);

    modelBuilder.Entity<ShoppingCart>()
        .HasOne(sc => sc.Product)
        .WithMany(p => p.ShoppingCarts)
        .HasForeignKey(sc => sc.ProductId);

    // Seed data
    modelBuilder.Entity<Role>().HasData(
        new Role { RoleId = 1, Name = "Admin" },
        new Role { RoleId = 2, Name = "User" }
    );

    modelBuilder.Entity<Account>().HasData(
        new Account { AccountId = 1, RoleId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Phone = "123456789" },
        new Account { AccountId = 2, RoleId = 2, FirstName = "Jane", LastName = "Doe", Email = "jane.doe@example.com", Phone = "987654321" }
    );

    modelBuilder.Entity<Category>().HasData(
        new Category { CategoryId = 1, Name = "Electronics" },
        new Category { CategoryId = 2, Name = "Books" }
    );

    modelBuilder.Entity<Product>().HasData(
        new Product { ProductId = 1, Name = "Laptop", Weight = 2.5, Width = 30.0, Height = 20.0, Depth = 2.0 },
        new Product { ProductId = 2, Name = "Book", Weight = 0.5, Width = 15.0, Height = 2.0, Depth = 0.5 }
    );

    modelBuilder.Entity<ProductCategory>().HasData(
        new ProductCategory { ProductId = 1, CategoryId = 1 },
        new ProductCategory { ProductId = 2, CategoryId = 2 }
    );

    modelBuilder.Entity<ShoppingCart>().HasData(
        new ShoppingCart { AccountId = 1, ProductId = 1, Amount = 1 },
        new ShoppingCart { AccountId = 2, ProductId = 2, Amount = 2 }
    );
    }
}