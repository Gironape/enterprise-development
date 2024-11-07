using AutoMapper;
using WarehouseEnterprise.Domain;
using WarehouseEnterprise.Api.Repositories;
using WarehouseEnterprise.Api.Dto;

namespace WarehouseEnterprise.Api.Services;

public class OrganizationService(IEntityRepository<Organization> repository, IMapper mapper) : IEntityService<OrganizationDto, OrganizationCreateDto>
{
    public IEnumerable<OrganizationDto> GetAll() => repository.GetAll().Select(mapper.Map<OrganizationDto>);
    public OrganizationDto? GetById(int id) => mapper.Map<OrganizationDto>(repository.GetById(id));

    public OrganizationDto Add(OrganizationCreateDto newProduct) => mapper.Map<OrganizationDto>(repository.Add(mapper.Map<Organization>(newProduct)));

    public bool Delete(int id)
    {
        var organization = repository.GetById(id);
        if (organization == null)
        {
            return false;
        }
        repository.Delete(organization);
        return true;
    }

    public OrganizationDto? Update(int id, OrganizationCreateDto updatedOrganization)
    {
        var organization = repository.GetById(id);
        if (organization == null)
        {
            return null;
        }
        organization.Address = updatedOrganization.Address;
        organization.Name = updatedOrganization.Name;
        return mapper.Map<OrganizationDto>(repository.Update(organization));
    }
}