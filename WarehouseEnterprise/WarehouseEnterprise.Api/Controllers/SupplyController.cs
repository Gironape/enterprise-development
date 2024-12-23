﻿using WarehouseEnterprise.Api.Dto;
using WarehouseEnterprise.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace WarehouseEnterprise.Api.Controllers;

/// <summary>
/// Контроллер для управления поставками.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SupplyController(IEntityService<SupplyDto, SupplyCreateDto> service) : ControllerBase
{
    /// <summary>
    /// Возвращает список всех поставок.
    /// </summary>
    /// <returns>Коллекция объектов <see cref="SupplyDto"/>.</returns>
    /// <response code="200">Список поставок успешно возвращён.</response>
    [HttpGet]
    public ActionResult<IEnumerable<SupplyDto>> Get()
    {
        return Ok(service.GetAll());
    }

    /// <summary>
    /// Получает информацию о поставке по её идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор поставки.</param>
    /// <returns>Объект <see cref="SupplyDto"/>, представляющий поставку.</returns>
    /// <response code="200">Поставка найдена и информация успешно возвращена.</response>
    /// <response code="404">Поставка с указанным идентификатором не найдена.</response>
    [HttpGet("{id}")]
    public ActionResult<SupplyDto> Get(int id)
    {
        var supply = service.GetById(id);
        if (supply == null)
        {
            return NotFound();
        }
        return Ok(supply);
    }

    /// <summary>
    /// Добавляет новую поставку.
    /// </summary>
    /// <param name="newSupply">Объект <see cref="SupplyCreateDto"/>, содержащий информацию о новой поставке.</param>
    /// <returns>Объект <see cref="SupplyDto"/>, представляющий добавленную поставку.</returns>
    /// <response code="201">Поставка успешно добавлена.</response>
    /// <response code="400">Ошибка при добавлении поставки.</response>
    [HttpPost]
    public ActionResult<SupplyDto> Post(SupplyCreateDto newSupply)
    {
        var result = service.Add(newSupply);
        if (result == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    /// <summary>
    /// Обновляет информацию о существующей поставке.
    /// </summary>
    /// <param name="id">Идентификатор поставки.</param>
    /// <param name="newSupply">Объект <see cref="SupplyCreateDto"/>, содержащий обновлённые данные поставки.</param>
    /// <returns>Объект <see cref="SupplyDTO"/>, представляющий обновлённую поставку.</returns>
    /// <response code="200">Поставка успешно обновлена.</response>
    /// <response code="404">Поставка с указанным идентификатором не найдена.</response>
    [HttpPut("{id}")]
    public ActionResult<SupplyDto> Put(int id, SupplyCreateDto newSupply)
    {
        var result = service.Update(id, newSupply);
        if (result == null)
        {
            return NotFound();
        }
        return Ok();
    }

    /// <summary>
    /// Удаляет поставку по её идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор поставки.</param>
    /// <returns>Результат операции удаления.</returns>
    /// <response code="200">Поставка успешно удалена.</response>
    /// <response code="404">Поставка с указанным идентификатором не найдена.</response>
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