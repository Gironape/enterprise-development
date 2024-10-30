using WarehouseEnterprise.Api.DTO;

namespace WarehouseEnterprise.Api.Services;
/// <summary>
/// Интерфейс для запросов
/// </summary>
public interface IQueryService
{
    /// <summary>
    /// Получить все товары отсортирванные по названию
    /// </summary>
    public List<ProductDTO> GetAllProductsSortedByName();

    /// <summary>
    /// Получить сведения о продукции предприятия, полученной в указанный день получателем продукции
    /// </summary>
    public List<ProductDTO> GetProductsRecieveOnDate(string name, DateTime date);

    /// <summary>
    /// Получить состояние склада на текущий момент с указанием номеров ячеек склада и их содержимого
    /// </summary>
    public List<CellDTO> GetCurrentWarehouseState();

    /// <summary>
    /// Получить информацию об организациях, получивших максимальный объем продукции за заданный период
    /// </summary>
    public List<OrganizationDTO> GetMaxSuppliesOrganizations(DateTime startDate, DateTime endDate);

    /// <summary>
    /// Получить топ 5 товаров по наличию на складе.
    /// </summary>
    public List<ProductQuantityDTO> GetFiveMaxQuantityProducts();

    /// <summary>
    /// Получить информацию о количестве поставленного товара по каждому товару и каждой организации
    /// </summary>
    public List<ProductSupplyToOrganizationsDTO> GetQuantityProductSupplyToOrganiztions();
}