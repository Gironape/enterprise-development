using AutoMapper;
using WarehouseEnterprise.Domain;
using WarehouseEnterprise.Api.Repositories;
using WarehouseEnterprise.Api.DTO;

namespace WarehouseEnterprise.Api.Services;

public class OrganizationService(IEntityRepository<Organization> repository, IMapper mapper) : IEntityService<OrganizationDTO, OrganizationCreateDTO>
{
    public IEnumerable<OrganizationDTO> GetAll() => repository.GetAll().Select(mapper.Map<OrganizationDTO>);
    public OrganizationDTO? GetById(int id) => mapper.Map<OrganizationDTO>(repository.GetById(id));

    public OrganizationDTO Add(OrganizationCreateDTO newProduct) => mapper.Map<OrganizationDTO>(repository.Add(mapper.Map<Organization>(newProduct)));

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

    public OrganizationDTO? Update(int id, OrganizationCreateDTO updatedOrganization)
    {
        var organization = repository.GetById(id);
        if (organization == null)
        {
            return null;
        }
        organization.Address = updatedOrganization.Address;
        organization.Name = updatedOrganization.Name;
        return mapper.Map<OrganizationDTO>(repository.Update(organization));
    }
}