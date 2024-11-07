namespace WarehouseEnterprise.Api.Dto;

/// <summary>
/// Dto для создания поставки
/// </summary>
public class SupplyCreateDto
{
    /// <summary>
    /// Идентификатор товара
    /// </summary>
    public required int ProductId { get; set; }
    /// <summary>
    /// Идентификатор организации
    /// </summary>
    public required int OrganizationId { get; set; }
    /// <summary>
    /// Дата поставки
    /// </summary>
    public required DateTime SupplyDate { get; set; }
    /// <summary>
    /// Количество поставленного товара
    /// </summary>
    public required int Quantity { get; set; }
}
