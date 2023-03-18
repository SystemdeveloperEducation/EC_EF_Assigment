using EF_CodeFirstApp.Context;
using EF_CodeFirstApp.Models.Entities;
using EF_CodeFirstApp.Models.Forms;
using Microsoft.EntityFrameworkCore;

namespace EF_CodeFirstApp.Services;

internal class ProductService
{
    private readonly DataContext _context = null!;
    private readonly CategoryService _categoryService = null!;

    public async Task<IEnumerable<ProductEntity>> GetallAsync()
    {
        // Includes the Category property in the query
        // This is a join query
        return await _context.Products.Include(x => x.Category).ToListAsync();
    }

    public async Task<ProductEntity> GetAsync(string articleNumber)
    {
        var producEntity = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.ArticleNumber == articleNumber);
        if (producEntity != null)
            return producEntity;

        return null!;
    }

    public async Task<ProductEntity> CreateAsync(ProductRegistrationForm productRegistrationForm)
    {
        if (await _context.Products.AnyAsync(x => x.ArticleNumber == productRegistrationForm.ArticleNumber))
            return null!;

        var productEntity = new ProductEntity
        {
            ArticleNumber = productRegistrationForm.ArticleNumber,
            Name = productRegistrationForm.Name,
            StockPrice = productRegistrationForm.StockPrice,
            CategoryId = (await _categoryService.GetOrCreateIfNotExistsAsync(productRegistrationForm.CategoryName)).Id,
        };

        _context.Add(productEntity);
        await _context.SaveChangesAsync();
        return productEntity;
    }

    public async Task DeleteAsync(string articleNumber)
    {
        // This is one way to do it
        //var productEntity = await getAsync(articleNumber);

        var producEntity = await _context.Products.FirstOrDefaultAsync(x => x.ArticleNumber == articleNumber);
        if (producEntity != null)
        {
            _context.Products.Remove(producEntity);
            await _context.SaveChangesAsync();
        }
    }


}
