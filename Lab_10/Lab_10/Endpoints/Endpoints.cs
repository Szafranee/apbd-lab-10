using FluentValidation;
using Lab_10.DTOs;
using Lab_10.Exceptions;
using Lab_10.Services;

namespace Lab_10.Endpoints;

public static class Endpoints
{
    public static void RegisterEndpoints(this WebApplication app)
    {
        // GET
        app.MapGet("api/accounts/{id:int}", async (int id, IAccountService service) =>
        {
            try
            {
                return Results.Ok(await service.GetAccountById(id));
            }
            catch (AccountNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        // POST
        app.MapPost("api/products", async (CreateProductDto createProductDto,
            IProductService service,
            IValidator<CreateProductDto> validator) =>
        {
            var validationResult = await validator.ValidateAsync(createProductDto);
            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }

            return await service.CreateProduct(createProductDto) ? Results.Created() : Results.NotFound();
        });
    }
}