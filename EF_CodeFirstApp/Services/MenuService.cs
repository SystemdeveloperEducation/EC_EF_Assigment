using EF_CodeFirstApp.Models.Entities;
using EF_CodeFirstApp.Models.Forms;

namespace EF_CodeFirstApp.Services;


public class Menu
{
    private readonly IssueService issueService = new IssueService();
    private readonly UserService userService = new UserService();

    public async Task MainMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        // Console.WriteLine("<<<<<<<<WELCOME TO THE ISSUER MENU>>>>>>>>");
        Console.WriteLine(@"  _____                             
  \_   \ ___  ___  _   _   ___  ___ 
   / /\// __|/ __|| | | | / _ \/ __|
/\/ /_  \__ \\__ \| |_| ||  __/\__ \  '(◣_◢)'
\____/  |___/|___/ \__,_| \___||___/ 

");

        Console.ResetColor();
        Console.WriteLine("1. Create a new issue");
        Console.WriteLine("2. Get all users");
        Console.WriteLine("3. Get user by email");
        Console.WriteLine("4. IssuesMenu");
        Console.WriteLine("5. Exit");
        Console.Write("\n|> ");
        var option = Console.ReadLine();
        switch (option)
        {
            case "1":
                await CreateIssue();
                break;
            case "2":
                await GetAllUsers();
                break;
            case "3":
                await GetUserByEmail();
                break;
            case "4":
                await Issues();
                break;
            case "5":
                Exit();
                break;
            default:
                Invalid();
                break;
        }
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }


    public async Task CreateIssue()
    {
        var regForm = GetInteractiveCreateIssue();
        await userService.CreateAsync(regForm);
    }

    public IssueRegistrationForm GetInteractiveCreateIssue()
    {
        var regForm = new IssueRegistrationForm();
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("<<<<<<<<CREATE A NEW ISSUE>>>>>>>>\n\n");
        Console.ResetColor();
        Console.WriteLine("Enter the first name:");
        regForm.FirstName = Console.ReadLine()!;
        Console.WriteLine("Enter the last name:");
        regForm.LastName = Console.ReadLine();
        Console.WriteLine("Enter the email:");
        regForm.Email = Console.ReadLine();
        Console.WriteLine("Enter the phone number:");
        regForm.PhoneNumber = Console.ReadLine();
        Console.WriteLine("Enter the role name:");
        regForm.RoleName = Console.ReadLine();
        Console.WriteLine("Describe the issue:");
        regForm.IssueDescription = Console.ReadLine();
        return regForm;
    }

    public async Task GetAllUsers()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("<<<<<<<<LIST OF THE ISSUERS>>>>>>>>\n");
        Console.ResetColor();
        var issues = await userService.GetallAsync();
        foreach (var issuer in issues)
        {
            Console.WriteLine($"|> {issuer.FirstName}, {issuer.LastName}, {issuer.Email}, {issuer.PhoneNumber}, {issuer.RoleId}, {issuer.Role.Name}\n");
        }
    }

    public async Task GetUserByEmail()
    {
        Console.Clear();
        Console.WriteLine("Enter Email\n");
        Console.Write("|> ");
        var email = Console.ReadLine();
        var issuerByEmail = await userService.GetAsync(email);
        Console.WriteLine($"{issuerByEmail.FirstName}, {issuerByEmail.LastName}, {issuerByEmail.Email}");
    }

    private async Task Issues()
    {
        Console.Clear();
        Console.ResetColor();
        Console.WriteLine("1. Get all issues");
        Console.WriteLine("2. Get issues by email");
        Console.WriteLine("3. Update issue status");
        Console.WriteLine("4. Exit");
        Console.Write("\n|> ");
        var option = Console.ReadLine();
        switch (option)
        {
            case "1":
                issueService.GetAllIssues();
                break;
            case "2":
                issueService.GeIssuesByEmail();
                break;
            case "3":
                issueService.UpdateIssuStatus();
                break;
            case "4":
                Exit();
                break;
            default:
                Invalid();
                break;
        }
        // Console.WriteLine("\nPress any key to continue...");
        // Console.ReadKey();
    }

    private void Exit()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("<<<<<<<<GOODBYE>>>>>>>>\n");
        Console.ResetColor();
        Environment.Exit(0);
    }

    private void Invalid()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("<<<<<<<<INVALID OPTION>>>>>>>>\n");
        Console.ResetColor();
    }
}
