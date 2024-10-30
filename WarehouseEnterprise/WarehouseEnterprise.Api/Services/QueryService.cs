using AutoMapper;
using WarehouseEnterprise.Domain;
using WarehouseEnterprise.Api.Repositories;
using WarehouseEnterprise.Api.DTO;

namespace WarehouseEnterprise.Api.Services;

public class QueryService(IEntityRepository<Cell> cellRepository, IEntityRepository<Supply> supplyRepository, IMapper mapper) : IQueryService
{
    public List<ProductDTO> GetAllProductsSortedByName()
    {
        return cellRepository.GetAll()
            .OrderBy(c => c.Product?.Name)
            .Select(c => mapper.Map<ProductDTO>(c.Product))
            .ToList();
    }

    public List<ProductDTO> GetProductsRecieveOnDate(string name, DateTime date)
    {
        return supplyRepository.GetAll()
            .Where(s => s.Organization.Name == name && s.SupplyDate.Date == date.Date)
            .Select(s => mapper.Map<ProductDTO>(s.Product))
            .ToList();
    }

    public List<CellDTO> GetCurrentWarehouseState()
    {
        return mapper.Map<List<CellDTO>>(cellRepository.GetAll());
    }

    public List<OrganizationDTO> GetMaxSuppliesOrganizations(DateTime startDate, DateTime endDate)
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
            .Select(o => mapper.Map<OrganizationDTO>(o.Organization))
            .ToList();

        return result;
    }

    public List<ProductQuantityDTO> GetFiveMaxQuantityProducts()
    {
        return cellRepository.GetAll()
            .GroupBy(c => c.Product?.Name)
            .Select(g => new ProductQuantityDTO
            {
                ProductName = g.Key,
                Quantity = g.Sum(c => c.Quantity),
            })
            .OrderByDescending(p => p.Quantity)
            .Take(5)
            .ToList();
    }

    public List<ProductSupplyToOrganizationsDTO> GetQuantityProductSupplyToOrganiztions()
    {
        return [.. supplyRepository.GetAll()
            .GroupBy(p => new { ProductName = p.Product.Name, OrganizationName = p.Organization.Name })
            .Select(g => new ProductSupplyToOrganizationsDTO
            {
                TotalQuantity = g.Sum(p => p.Quantity),
                ProductName = g.Key.ProductName,
                OrganizationName = g.Key.OrganizationName,
            })
            .OrderByDescending(p => p.TotalQuantity)];
    }
}