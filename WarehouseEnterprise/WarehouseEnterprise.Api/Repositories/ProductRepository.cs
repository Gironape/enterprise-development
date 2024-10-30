using WarehouseEnterprise.Domain.Context;
using WarehouseEnterprise.Domain;
using Microsoft.EntityFrameworkCore;

namespace WarehouseEnterprise.Api.Repositories;

public class ProductRepository(WarehouseContext context) : IEntityRepository<Product>
{
    public IEnumerable<Product> GetAll() => context.Products;

    public Product? GetById(int id) => context.Products.Find(id);

    public Product Add(Product newProduct)
    {
        var product = context.Products.Add(newProduct).Entity;
        context.SaveChanges();
        return product;
    }

    public void Delete(Product product)
    {
        context.Products.Remove(product);
        context.SaveChanges();
    }

    public Product Update(Product updatedProduct)
    {
        var entry = context.Entry(updatedProduct);
        entry.State = EntityState.Modified;
        context.SaveChanges();
        return entry.Entity;
    }
}
