using AutoMapper;
using WarehouseEnterprise.Domain;
using WarehouseEnterprise.Api.Dto;
namespace WarehouseEnterprise.Api.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Organization, OrganizationDto>().ReverseMap();
        CreateMap<Organization, OrganizationCreateDto>().ReverseMap();

        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Product, ProductCreateDto>().ReverseMap();

        CreateMap<Cell, CellDto>().ReverseMap();

        CreateMap<Supply, SupplyDto>().ReverseMap();
    }
}