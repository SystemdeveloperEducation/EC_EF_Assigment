using EF_CodeFirstApp.Context;
using EF_CodeFirstApp.Models.Entities;
using EF_CodeFirstApp.Models.Forms;
using Microsoft.EntityFrameworkCore;

namespace EF_CodeFirstApp.Services;

internal class UserService
{
    private readonly DataContext _context = new DataContext();
    private readonly RoleService _roleService = new RoleService();
    private readonly IssueService _issueService = new IssueService();
    public async Task<IEnumerable<UserEntity>> GetallAsync()
    {
        // Includes the Role property in the query
        // This is a join query
        return await _context.Users.Include(x => x.Role).ToListAsync();
    }

    public async Task<UserEntity> GetAsync(string email)
    {
        var userEntity = await _context.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Email == email);
        if (userEntity != null)
            return userEntity;

        return null!;
    }

    public async Task<UserEntity> CreateAsync(IssueRegistrationForm issueRegistrationForm)
    {
        System.Console.WriteLine($"entering the CreateAsync method with {issueRegistrationForm.Email}");
        if (await _context.Users.AnyAsync(x => x.Email == issueRegistrationForm.Email))
        {
            System.Console.WriteLine($"found the email {issueRegistrationForm.Email} in the database");
            return null!;
        }
        System.Console.WriteLine($"did not find the email {issueRegistrationForm.Email} in the database creating new Issuer");
        // var roleEntity = new RoleEntity()
        // {
        //     Id = 1,
        // };
        var userEntity = new UserEntity()
        {
            FirstName = issueRegistrationForm.FirstName,
            LastName = issueRegistrationForm.LastName,
            Email = issueRegistrationForm.Email,
            PhoneNumber = issueRegistrationForm.PhoneNumber,
            RoleId = (await _roleService.GetOrCreateIfNotExistsAsync(issueRegistrationForm.RoleName)).Id,
            // Issues = (await _issueService.GetOrCreateIfNotExistsAsync(issueRegistrationForm.IssueDescription, issueRegistrationForm.Email)).Id,
            // CategoryId = (await _roreService.GetOrCreateIfNotExistsAsync(productRegistrationForm.CategoryName)).Id,
        };
        Console.WriteLine($"created the Issuer Model with {userEntity.FirstName}, {userEntity.Email}, {userEntity.RoleId}");
        _context.Add(userEntity);
        System.Console.WriteLine("added the Issuer to the context");
        await _context.SaveChangesAsync();
        System.Console.WriteLine("saved the changes to the database");
        return userEntity;
    }

    // public async Task DeleteAsync(string email)
    // {
    //     // This is one way to do it
    //     //var userEntity = await getAsync(articleNumber);
    //     var userEntity = await _context.Issuers.FirstOrDefaultAsync(x => x.Email == email);
    //     if (userEntity != null)
    //     {
    //         _context.Issuers.Remove(userEntity);
    //         await _context.SaveChangesAsync();
    //     }
    // }
}
