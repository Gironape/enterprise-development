using WarehouseEnterprise.Api.Dto;
using WarehouseEnterprise.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace WarehouseEnterprise.Api.Controllers;

/// <summary>
/// Контроллер для управления организациями.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class OrganizationController(IEntityService<OrganizationDto, OrganizationCreateDto> service) : ControllerBase
{
    /// <summary>
    /// Возвращает список всех организаций.
    /// </summary>
    /// <returns>Коллекция объектов <see cref="OrganizationDto"/>.</returns>
    /// <response code="200">Список организаций успешно возвращён.</response>
    [HttpGet]
    public ActionResult<IEnumerable<OrganizationDto>> Get()
    {
        return Ok(service.GetAll());
    }

    /// <summary>
    /// Возвращает информацию об организации по её идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор организации.</param>
    /// <returns>Объект <see cref="OrganizationDto"/>, представляющий организацию.</returns>
    /// <response code="200">Организация найдена и информация успешно возвращена.</response>
    /// <response code="404">Организация с указанным идентификатором не найдена.</response>
    [HttpGet("{id}")]
    public ActionResult<OrganizationDto> Get(int id)
    {
        var organization = service.GetById(id);
        if (organization == null)
        {
            return NotFound();
        }
        return Ok(organization);
    }

    /// <summary>
    /// Добавляет новую организацию.
    /// </summary>
    /// <param name="newOrganization">Объект <see cref="OrganizationCreateDto"/>, содержащий данные новой организации.</param>
    /// <returns>Объект <see cref="OrganizationDto"/>, представляющий добавленную организацию.</returns>
    /// <response code="201">Организация успешно добавлена.</response>
    [HttpPost]
    public ActionResult<OrganizationDto> Post(OrganizationCreateDto newOrganization)
    {
        var result = service.Add(newOrganization);

        if (result == null)
        {
            return NotFound("Not Found");
        }

        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    /// <summary>
    /// Обновляет существующую организацию.
    /// </summary>
    /// <param name="id">Идентификатор обновляемой организации.</param>
    /// <param name="newOrganization">Объект <see cref="OrganizationCreateDto"/>, содержащий обновлённые данные организации.</param>
    /// <returns>Объект <see cref="OrganizationDto"/>, представляющий обновлённую организацию.</returns>
    /// <response code="200">Организация успешно обновлена.</response>
    /// <response code="404">Организация с указанным идентификатором не найдена.</response>
    [HttpPut("{id}")]
    public ActionResult<OrganizationDto> Put(int id, OrganizationCreateDto newOrganization)
    {
        var result = service.Update(id, newOrganization);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    /// <summary>
    /// Удаляет организацию по её идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор организации для удаления.</param>
    /// <returns>Результат операции удаления.</returns>
    /// <response code="200">Организация успешно удалена.</response>
    /// <response code="404">Организация с указанным идентификатором не найдена.</response>
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var result = service.Delete(id);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }
}