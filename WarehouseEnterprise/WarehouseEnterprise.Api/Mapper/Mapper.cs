using AutoMapper;
using WarehouseEnterprise.Domain;
using WarehouseEnterprise.Api.DTO;
namespace WarehouseEnterprise.Api.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Organization, OrganizationDTO>().ReverseMap();
        CreateMap<Organization, OrganizationCreateDTO>().ReverseMap();

        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<Product, ProductCreateDTO>().ReverseMap();

        CreateMap<Cell, CellDTO>().ReverseMap();

        CreateMap<Supply, SupplyDTO>().ReverseMap();
    }
}