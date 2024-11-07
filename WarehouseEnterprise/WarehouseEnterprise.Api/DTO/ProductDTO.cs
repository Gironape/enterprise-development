namespace WarehouseEnterprise.Api.Dto;

/// <summary>
/// Dto для товара
/// </summary>
public class ProductDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public required int Id { get; set; }
    /// <summary>
    /// Код товара
    /// </summary>
    public required int Code { get; set; }
    /// <summary>
    /// Название
    /// </summary>
    public required string Name { get; set; }
}
