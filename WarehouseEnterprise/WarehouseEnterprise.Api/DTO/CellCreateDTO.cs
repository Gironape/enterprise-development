namespace WarehouseEnterprise.Api.Dto;

/// <summary>
/// Dto для создания ячейки
/// </summary>
public class CellCreateDto
{
    /// <summary>
    /// Идентификатор товара
    /// </summary>
    public required int ProductId { get; set; }
    /// <summary>
    /// Количество товара в ячейке
    /// </summary>
    public required int Quantity { get; set; }
}