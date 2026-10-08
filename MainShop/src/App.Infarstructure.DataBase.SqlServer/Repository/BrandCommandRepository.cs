using App.Domain.Core.Brand.Entities;
using App.Infarstructure.DataBase.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

public class BrandCommandRepository : IBrandCommandRepository
{
    private readonly AppDbContext _appDbContext;

    public BrandCommandRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task Add(string name, int displayOrder, DateTime creationDate, bool isDeleted)
    {
        var brand = new Brand();
        brand.Name = name;
        brand.DisplayOrder = displayOrder;
        brand.CreationDate = creationDate;
        brand.IsDeleted = isDeleted;
       await _appDbContext.Brands.AddAsync(brand);
        await _appDbContext.SaveChangesAsync();
    }


    public async Task Remove(int id)
    {
        var removeBrand = await _appDbContext.Brands.SingleOrDefaultAsync(x => x.Id == id);
       _appDbContext.Brands.Remove(removeBrand);
       await _appDbContext.SaveChangesAsync();
    }

    public async Task Edit(int id, string name, int displayOrder,bool isDeleted)
    {
        var brandUpdate = await _appDbContext.Brands.SingleOrDefaultAsync(x => x.Id == id);
        brandUpdate.DisplayOrder = displayOrder;
        brandUpdate.Name = name;
        brandUpdate.IsDeleted = isDeleted;
       await _appDbContext.SaveChangesAsync();

    }

}