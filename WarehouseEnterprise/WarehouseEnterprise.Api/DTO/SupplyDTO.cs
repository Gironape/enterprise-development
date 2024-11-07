namespace WarehouseEnterprise.Api.Dto;

/// <summary>
/// Dto поставки
/// </summary>
public class SupplyDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public required int Id { get; set; }
    /// <summary>
    /// Товар
    /// </summary>
    public required ProductDto Product { get; set; }
    /// <summary>
    /// Организация
    /// </summary>
    public required OrganizationDto Organization { get; set; }
    /// <summary>
    /// Дата поставки
    /// </summary>
    public required DateTime SupplyDate { get; set; }
    /// <summary>
    /// Количество поставленного товара
    /// </summary>
    public required int Quantity { get; set; }
}