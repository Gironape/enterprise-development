using AutoMapper;
using WarehouseEnterprise.Domain;
using WarehouseEnterprise.Api.Repositories;
using WarehouseEnterprise.Api.Dto;

namespace WarehouseEnterprise.Api.Services;

public class CellService(IEntityRepository<Cell> cellRepository, IEntityRepository<Product> productRepository, IMapper mapper) : IEntityService<CellDto, CellCreateDto>
{
    public IEnumerable<CellDto> GetAll() => cellRepository.GetAll().Select(mapper.Map<CellDto>);

    public CellDto? GetById(int id) => mapper.Map<CellDto>(cellRepository.GetById(id));

    public CellDto? Add(CellCreateDto newCell)
    {
        var product = productRepository.GetById(newCell.ProductId);
        if (product == null)
        {
            return null;
        }
        var cell = new Cell
        {
            Product = product,
            Quantity = newCell.Quantity,
        };
        return mapper.Map<CellDto>(cellRepository.Add(cell));
    }
    public bool Delete(int id)
    {
        var cell = cellRepository.GetById(id);
        if (cell == null)
        {
            return false;
        }
        cellRepository.Delete(cell);
        return true;
    }

    public CellDto? Update(int id, CellCreateDto updatedCell)
    {
        var cell = cellRepository.GetById(id);
        if (cell == null)
        {
            return null;
        }
        var product = productRepository.GetById(updatedCell.ProductId);
        if (product == null)
        {
            return null;
        }
        cell.Product = product;
        cell.Quantity = updatedCell.Quantity;
        return mapper.Map<CellDto>(cellRepository.Update(cell));
    }
}