namespace WarehouseEnterprise.Api.Dto;

/// <summary>
/// Dto для создания товара
/// </summary>
public class ProductCreateDto
{
    /// <summary>
    /// Код товара
    /// </summary>
    public required int Code { get; set; }

    /// <summary>
    /// Название
    /// </summary>
    public required string Name { get; set; }
}
