using WarehouseEnterprise.Domain.Context;
using Microsoft.EntityFrameworkCore;

namespace WarehouseEnterprise.Domain.Repositories;

public class SupplyRepository(WarehouseContext context) : IEntityRepository<Supply>
{
    public IEnumerable<Supply> GetAll()
    {
        return context.Supplies
            .Include(s => s.Product)
            .Include(s => s.Organization);
    }

    public Supply? GetById(int id)
    {
        return context.Supplies
            .Include(s => s.Product)
            .Include(s => s.Organization)
            .FirstOrDefault(s => s.Id == id);
    }

    public Supply Add(Supply newSupply)
    {
        var supply = context.Supplies.Add(newSupply).Entity;
        context.SaveChanges();
        return supply;
    }

    public void Delete(Supply supply)
    {
        context.Supplies.Remove(supply);
        context.SaveChanges();
    }

    public Supply Update(Supply updatedSupply)
    {
        var entry = context.Entry(updatedSupply);
        entry.State = EntityState.Modified;
        context.SaveChanges();
        return entry.Entity;
    }
}
