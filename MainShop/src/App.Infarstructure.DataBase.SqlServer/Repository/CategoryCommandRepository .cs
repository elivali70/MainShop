using App.Domain.Core.Category.Entities;
using App.Infarstructure.DataBase.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

public class CategoryCommandRepository : ICategoryCommandRepository
{
    private readonly AppDbContext _appDbContext;

    public CategoryCommandRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task Add(string name, int displayOrder, int? parentCategoryId,bool isActive)
    {
        var category = new Category();
        category.Name = name;
        category.DisplayOrder = displayOrder;
        category.ParentCategoryId = parentCategoryId;
        category.IsActive = isActive;   
       await _appDbContext.Categories.AddAsync(category);
        await _appDbContext.SaveChangesAsync();
    }


    public async Task Remove(int id)
    {
        var removeCategory = await _appDbContext.Categories.SingleOrDefaultAsync(x => x.Id == id);
       _appDbContext.Categories.Remove(removeCategory);
       await _appDbContext.SaveChangesAsync();
    }

    public async Task Edit(int id, string name, int displayOrder, int? parentCategoryId, bool isActive)
    {
        var categoryUpdate = await _appDbContext.Categories.SingleOrDefaultAsync(x => x.Id == id);
        categoryUpdate.DisplayOrder = displayOrder;
        categoryUpdate.Name = name;
       categoryUpdate.ParentCategoryId = parentCategoryId;
        categoryUpdate.IsActive = isActive;
       await _appDbContext.SaveChangesAsync();

    }

}