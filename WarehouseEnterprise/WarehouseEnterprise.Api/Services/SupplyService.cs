using AutoMapper;
using WarehouseEnterprise.Domain;
using WarehouseEnterprise.Api.Repositories;
using WarehouseEnterprise.Api.Dto;

namespace WarehouseEnterprise.Api.Services;

public class SupplyService(IEntityRepository<Supply> supplyRepository, IEntityRepository<Organization> organizationRepository, IEntityRepository<Product> productRepository, IMapper mapper) : IEntityService<SupplyDto, SupplyCreateDto>
{
    public IEnumerable<SupplyDto> GetAll() => supplyRepository.GetAll().Select(mapper.Map<SupplyDto>);

    public SupplyDto? GetById(int id) => mapper.Map<SupplyDto>(supplyRepository.GetById(id));

    public SupplyDto? Add(SupplyCreateDto newSupply)
    {
        var organization = organizationRepository.GetById(newSupply.OrganizationId);
        var product = productRepository.GetById(newSupply.ProductId);
        if (organization == null || product == null)
        {
            return null;
        }
        var supply = new Supply
        {
            Organization = organization,
            Product = product,
            SupplyDate = newSupply.SupplyDate,
            Quantity = newSupply.Quantity,
        };
        return mapper.Map<SupplyDto>(supplyRepository.Add(supply));
    }

    public bool Delete(int id)
    {
        var supply = supplyRepository.GetById(id);
        if (supply == null)
        {
            return false;
        }
        supplyRepository.Delete(supply);
        return true;
    }

    public SupplyDto? Update(int id, SupplyCreateDto updatedSupply)
    {
        var supply = supplyRepository.GetById(id);
        if (supply == null)
        {
            return null;
        }
        var product = productRepository.GetById(updatedSupply.ProductId);
        var organization = organizationRepository.GetById(updatedSupply.OrganizationId);
        if (product == null || organization == null)
        {
            return null;
        }
        supply.Product = product;
        supply.Organization = organization;
        supply.SupplyDate = updatedSupply.SupplyDate;
        supply.Quantity = updatedSupply.Quantity;
        return mapper.Map<SupplyDto>(supplyRepository.Update(supply));
    }
}