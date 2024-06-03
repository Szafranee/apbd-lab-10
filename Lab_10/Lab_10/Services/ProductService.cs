using Lab_10.Contexts;
using Lab_10.DTOs;
using Lab_10.Models;

namespace Lab_10.Services;

public interface IProductService
{
    Task<bool> CreateProduct(CreateProductDto createProductDto);
}

public class ProductService(DatabaseContext db) : IProductService
{
    public async Task<bool> CreateProduct(CreateProductDto createProductDto)
    {
        try
        {
            var product = new Product()
            {
                Name = createProductDto.ProductName,
                Weight = createProductDto.ProductWeight,
                Width = createProductDto.ProductWidth,
                Height = createProductDto.ProductHeight,
                Depth = createProductDto.ProductDepth,
                ProductsCategories = createProductDto.ProductCategories.Select(id =>
                    new ProductCategory()
                    {
                        CategoryId = id
                    }
                ).ToList()
            };

            db.Products.Add(product);
            await db.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}