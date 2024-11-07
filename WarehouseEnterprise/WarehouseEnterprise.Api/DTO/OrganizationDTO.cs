namespace WarehouseEnterprise.Api.Dto;

/// <summary>
/// Dto организации
/// </summary>
public class OrganizationDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public required int Id { get; set; }
    /// <summary>
    /// Название
    /// </summary>
    public required string Name { get; set; }
    /// <summary>
    /// Адрес
    /// </summary>
    public required string Address { get; set; }
}