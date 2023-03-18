using EF_CodeFirstApp.Context;
using EF_CodeFirstApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_CodeFirstApp.Services;

internal class CategoryService
{
    private readonly DataContext _context = null!;

    public async Task<CategoryEntity> GetOrCreateIfNotExistsAsync(string categoryName)
    {
        var categoryEntity = await _context.Categories.FirstOrDefaultAsync(x => x.Name == categoryName);
        if (categoryEntity == null)
        {
            categoryEntity = new CategoryEntity
            {
                Name = categoryName
            };
            await _context.Categories.AddAsync(categoryEntity);
            await _context.SaveChangesAsync();
        }
        return categoryEntity;
    }

    public async Task<IEnumerable<CategoryEntity>> GetallAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task DeleteAsync(string categoryName)
    {
        var categoryEntity = await _context.Categories.FirstOrDefaultAsync(x => x.Name == categoryName);
        if (categoryEntity != null)
        {
            _context.Remove(categoryEntity);
            await _context.SaveChangesAsync();
        }
    }
}
