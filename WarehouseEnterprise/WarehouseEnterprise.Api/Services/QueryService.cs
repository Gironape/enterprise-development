using AutoMapper;
using WarehouseEnterprise.Domain;
using WarehouseEnterprise.Api.Repositories;
using WarehouseEnterprise.Api.Dto;

namespace WarehouseEnterprise.Api.Services;

public class QueryService(IEntityRepository<Cell> cellRepository, IEntityRepository<Supply> supplyRepository, IMapper mapper) : IQueryService
{
    public List<ProductDto> GetAllProductsSortedByName()
    {
        return cellRepository.GetAll()
            .OrderBy(c => c.Product?.Name)
            .Select(c => mapper.Map<ProductDto>(c.Product))
            .ToList();
    }

    public List<ProductDto> GetProductsRecieveOnDate(string name, DateTime date)
    {
        return supplyRepository.GetAll()
            .Where(s => s.Organization.Name == name && s.SupplyDate.Date == date.Date)
            .Select(s => mapper.Map<ProductDto>(s.Product))
            .ToList();
    }

    public List<CellDto> GetCurrentWarehouseState()
    {
        return mapper.Map<List<CellDto>>(cellRepository.GetAll());
    }

    public List<OrganizationDto> GetMaxSuppliesOrganizations(DateTime startDate, DateTime endDate)
    {
        var organizationsWithMaxSupply = supplyRepository.GetAll()
            .Where(s => s.SupplyDate >= startDate && s.SupplyDate <= endDate)
            .GroupBy(s => s.Organization)
            .Select(g => new
            {
                Organization = g.Key,
                TotalQuantity = g.Sum(s => s.Quantity)
            })
            .ToList();
        if (organizationsWithMaxSupply.Count == 0)
        {
            return [];
        }
        var maxQuantity = organizationsWithMaxSupply.Max(o => o.TotalQuantity);
        var result = organizationsWithMaxSupply
            .Where(o => o.TotalQuantity == maxQuantity)
            .Select(o => mapper.Map<OrganizationDto>(o.Organization))
            .ToList();

        return result;
    }

    public List<ProductQuantityDto> GetFiveMaxQuantityProducts()
    {
        return cellRepository.GetAll()
            .GroupBy(c => c.Product?.Name)
            .Select(g => new ProductQuantityDto
            {
                ProductName = g.Key,
                Quantity = g.Sum(c => c.Quantity),
            })
            .OrderByDescending(p => p.Quantity)
            .Take(5)
            .ToList();
    }

    public List<ProductSupplyToOrganizationsDto> GetQuantityProductSupplyToOrganiztions()
    {
        return [.. supplyRepository.GetAll()
            .GroupBy(p => new { ProductName = p.Product.Name, OrganizationName = p.Organization.Name })
            .Select(g => new ProductSupplyToOrganizationsDto
            {
                TotalQuantity = g.Sum(p => p.Quantity),
                ProductName = g.Key.ProductName,
                OrganizationName = g.Key.OrganizationName,
            })
            .OrderByDescending(p => p.TotalQuantity)];
    }
}