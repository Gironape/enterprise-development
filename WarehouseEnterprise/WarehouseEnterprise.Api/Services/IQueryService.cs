using WarehouseEnterprise.Api.Dto;

namespace WarehouseEnterprise.Api.Services;
/// <summary>
/// Интерфейс для запросов
/// </summary>
public interface IQueryService
{
    /// <summary>
    /// Получить все товары отсортированные по названию
    /// </summary>
    public List<ProductDto> GetAllProductsSortedByName();

    /// <summary>
    /// Получить сведения о продукции предприятия, полученной в указанный день получателем продукции
    /// </summary>
    public List<ProductDto> GetProductsRecieveOnDate(string name, DateTime date);

    /// <summary>
    /// Получить состояние склада на текущий момент с указанием номеров ячеек склада и их содержимого
    /// </summary>
    public List<CellDto> GetCurrentWarehouseState();

    /// <summary>
    /// Получить информацию об организациях, получивших максимальный объем продукции за заданный период
    /// </summary>
    public List<OrganizationDto> GetMaxSuppliesOrganizations(DateTime startDate, DateTime endDate);

    /// <summary>
    /// Получить топ 5 товаров по наличию на складе.
    /// </summary>
    public List<ProductQuantityDto> GetFiveMaxQuantityProducts();

    /// <summary>
    /// Получить информацию о количестве поставленного товара по каждому товару и каждой организации
    /// </summary>
    public List<ProductSupplyToOrganizationsDto> GetQuantityProductSupplyToOrganiztions();
}