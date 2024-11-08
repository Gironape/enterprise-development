namespace WarehouseEnterprise.Api.Services;
/// <summary>
///  Интерфейс для сервисов сущностей
/// </summary>
public interface IEntityService<Dto, CreateDto>
{
    /// <summary>
    /// Получение всех сущностей
    /// </summary>
    public IEnumerable<Dto> GetAll();

    /// <summary>
    /// Получение сущности при помощи id
    /// </summary>
    Dto? GetById(int id);

    /// <summary>
    /// Добавление сущности
    /// </summary>
    Dto? Add(CreateDto entity);

    /// <summary>
    /// Удаление сущности
    /// </summary>
    bool Delete(int id);

    /// <summary>
    /// Изменение сущности
    /// </summary>
    Dto? Update(int id, CreateDto updatedEntity);
}