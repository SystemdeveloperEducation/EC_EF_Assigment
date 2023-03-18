using EF_CodeFirstApp.Context;
using EF_CodeFirstApp.Models.Entities;
using EF_CodeFirstApp.Models.Forms;
using Microsoft.EntityFrameworkCore;

namespace EF_CodeFirstApp.Services;

internal class IssuerService
{
    private readonly DataContext _context;
    private readonly RoleService _roleService = null!;

    public async Task<IEnumerable<IssuersEntity>> GetallAsync()
    {
        // Includes the Category property in the query
        // This is a join query
        return await _context.Issuers.Include(x => x.Role).ToListAsync();
    }

    public async Task<IssuersEntity> GetAsync(string email)
    {
        var issuersEntity = await _context.Issuers.Include(x => x.Role).FirstOrDefaultAsync(x => x.Email == email);
        if (issuersEntity != null)
            return issuersEntity;

        return null!;
    }

    public async Task<IssuersEntity> CreateAsync(IssuerRegistrationForm issuerRegistrationForm)
    {
        System.Console.WriteLine($"entering the CreateAsync method with {issuerRegistrationForm.Email}");
        if (await _context.Issuers.AnyAsync(x => x.Email == issuerRegistrationForm.Email))
        {
            System.Console.WriteLine($"found the email {issuerRegistrationForm.Email} in the database");
            return null!;
        }
        System.Console.WriteLine($"did not find the email {issuerRegistrationForm.Email} in the database creating new Issuer");
        var roleEntity = new RoleEntity()
        {
            Id = 1,
        };
        var IssuersEntity = new IssuersEntity()
        {
            FirstName = issuerRegistrationForm.FirstName,
            LastName = issuerRegistrationForm.LastName,
            Email = issuerRegistrationForm.Email,
            PhoneNumber = issuerRegistrationForm.PhoneNumber,
            RoleId = roleEntity.Id //(await _roleService.GetOrCreateIfNotExistsAsync(issuerRegistrationForm.RoleName)).Id,
            // CategoryId = (await _roreService.GetOrCreateIfNotExistsAsync(productRegistrationForm.CategoryName)).Id,
        };
        Console.WriteLine($"created the Issuer Model with {IssuersEntity.FirstName}, {IssuersEntity.Email}, {IssuersEntity.RoleId}");
        _context.Add(IssuersEntity);
        System.Console.WriteLine("added the Issuer to the context");
        await _context.SaveChangesAsync();
        System.Console.WriteLine("saved the changes to the database");
        return IssuersEntity;
    }

    // public async Task DeleteAsync(string email)
    // {
    //     // This is one way to do it
    //     //var IssuersEntity = await getAsync(articleNumber);
    //     var issuersEntity = await _context.Issuers.FirstOrDefaultAsync(x => x.Email == email);
    //     if (issuersEntity != null)
    //     {
    //         _context.Issuers.Remove(issuersEntity);
    //         await _context.SaveChangesAsync();
    //     }
    // }
}
