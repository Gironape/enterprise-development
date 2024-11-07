namespace WarehouseEnterprise.Api.Dto;

/// <summary>
/// Dto описывающее продукт и его количество на складе
/// </summary>
public class ProductQuantityDto
{
    /// <summary>
    /// Название товара
    /// </summary>
    public string? ProductName { get; set; }

    /// <summary>
    /// Количество товара
    /// </summary>
    public int Quantity { get; set; }
}
