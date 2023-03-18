using EF_CodeFirstApp.Context;
using EF_CodeFirstApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_CodeFirstApp.Services;

internal class RoleService
{
    private readonly DataContext _context = null!;

    public async Task<RoleEntity> GetOrCreateIfNotExistsAsync(string roleName)
    {
        var roleEntity = await _context.Roles.FirstOrDefaultAsync(x => x.Name == roleName);
        System.Console.WriteLine($"Inside getOrcreate ROLES <<<<<  {roleEntity.Name}");
        if (roleEntity == null)
        {
            roleEntity = new RoleEntity
            {
                Name = roleName
            };
            System.Console.WriteLine($"Created new Role entetity with name {roleEntity.Name}");
            await _context.Roles.AddAsync(roleEntity);
            await _context.SaveChangesAsync();
        }
        return roleEntity;
    }

    public async Task<IEnumerable<RoleEntity>> GetallAsync()
    {
        return await _context.Roles.ToListAsync();
    }

    public async Task DeleteAsync(string categoryName)
    {
        var roleEntity = await _context.Roles.FirstOrDefaultAsync(x => x.Name == categoryName);
        if (roleEntity != null)
        {
            _context.Remove(roleEntity);
            await _context.SaveChangesAsync();
        }
    }
}
