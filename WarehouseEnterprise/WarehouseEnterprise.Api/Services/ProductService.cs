using AutoMapper;
using WarehouseEnterprise.Domain;
using WarehouseEnterprise.Domain.Repositories;
using WarehouseEnterprise.Api.Dto;

namespace WarehouseEnterprise.Api.Services;

public class ProductService(IEntityRepository<Product> repository, IMapper mapper) : IEntityService<ProductDto, ProductCreateDto>
{
    public IEnumerable<ProductDto> GetAll() => repository.GetAll().Select(mapper.Map<ProductDto>);

    public ProductDto? GetById(int id) => mapper.Map<ProductDto>(repository.GetById(id));

    public ProductDto Add(ProductCreateDto newProduct) => mapper.Map<ProductDto>(repository.Add(mapper.Map<Product>(newProduct)));

    public bool Delete(int id)
    {
        var product = repository.GetById(id);
        if (product == null)
        {
            return false;
        }
        repository.Delete(product);
        return true;
    }

    public ProductDto? Update(int id, ProductCreateDto updatedProduct)
    {
        var product = repository.GetById(id);
        if (product == null)
        {
            return null;
        }
        product.Name = updatedProduct.Name;
        product.Code = updatedProduct.Code;
        return mapper.Map<ProductDto>(repository.Update(product));
    }
}