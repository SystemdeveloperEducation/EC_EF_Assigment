using EF_CodeFirstApp.Context;
using EF_CodeFirstApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_CodeFirstApp.Services;

public class IssueService
{
    private readonly DataContext _context = new DataContext();



    public void UpdateIssuStatus()
    {
        Console.WriteLine("This is the userStatus");
    }

    public void GeIssuesByEmail()
    {
        Console.WriteLine("this is the GetIssuesByEmail");
    }

    public void GetAllIssues()
    {
        Console.WriteLine("this is the GetIssuesByEmail");
    }

    // public async Task<IssueEntity> GetOrCreateIfNotExistsAsync(string issueDescription, int userId)
    // {
    //     System.Console.WriteLine("INSIDE GETORCREATE!!!");
    //     var issueEntity = await _context.Issues.FirstOrDefaultAsync(x => x.UserId == userId);  //.Roles.FirstOrDefaultAsync(x => x.Name == roleName);
    //     if (issueEntity == null)
    //     {
    //         issueEntity = new IssueEntity
    //         {
    //             Description = issueDescription,
    //         };

    //         System.Console.WriteLine($"Created new Issue entetity with id: {issueEntity.Id} by user {issueEntity.UserId}");
    //         await _context.Issues.AddAsync(issueEntity);
    //         await _context.SaveChangesAsync();
    //     }
    //     System.Console.WriteLine("Changes SAVED");
    //     return issueEntity;
    // }
}
