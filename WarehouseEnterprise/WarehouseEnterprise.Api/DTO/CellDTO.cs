namespace WarehouseEnterprise.Api.Dto;

/// <summary>
/// Dto ячейки
/// </summary>
public class CellDto
{
    /// <summary>
    /// Идентификатор ячейки
    /// </summary>
    public required int Id { get; set; }
    /// <summary>
    /// Товар
    /// </summary>
    public ProductDto? Product { get; set; }
    /// <summary>
    /// Количество товара в ячейке
    /// </summary>
    public required int Quantity { get; set; }
}