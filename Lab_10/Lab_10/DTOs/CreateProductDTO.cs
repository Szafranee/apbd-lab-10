namespace Lab_10.DTOs;

public record CreateProductDto(string ProductName, double ProductWeight, double ProductWidth,
    double ProductHeight, double ProductDepth, List<int> ProductCategories);