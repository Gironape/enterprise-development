namespace WarehouseEnterprise.Api.Dto;

/// <summary>
/// Dto для создания организации
/// </summary>
public class OrganizationCreateDto
{
    /// <summary>
    /// Название
    /// </summary>
    public required string Name { get; set; }
    /// <summary>
    /// Адрес
    /// </summary>
    public required string Address { get; set; }
}
