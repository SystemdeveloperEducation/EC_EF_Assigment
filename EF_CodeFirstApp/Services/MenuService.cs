using EF_CodeFirstApp.Models.Entities;
using EF_CodeFirstApp.Models.Forms;

namespace EF_CodeFirstApp.Services;


public class Menu
{
    private readonly IssuerService issuerService = new IssuerService();

    public async Task MainMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red; ;
        // Console.WriteLine("<<<<<<<<WELCOME TO THE ISSUER MENU>>>>>>>>");
        Console.WriteLine(@"  _____                             
  \_   \ ___  ___  _   _   ___  ___ 
   / /\// __|/ __|| | | | / _ \/ __|
/\/ /_  \__ \\__ \| |_| ||  __/\__ \
\____/  |___/|___/ \__,_| \___||___/");
        Console.ResetColor();
        Console.WriteLine("1. Create a new issuer");
        Console.WriteLine("2. Get all issuers");
        Console.WriteLine("3. Exit");
        var option = Console.ReadLine();
        switch (option)
        {
            case "1":
                await CreateIssuer();
                break;
            case "2":
                await Getall();
                break;
            case "3":
                Console.WriteLine("<<<<<<<<GOODBYE>>>>>>>>");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("<<<<<<<<INVALID OPTION>>>>>>>>");
                break;
        }
        Console.ReadKey();
    }


    public async Task CreateIssuer()
    {
        var regForm = new IssuerRegistrationForm();
        Console.Clear();
        Console.WriteLine("<<<<<<<<CREATE A NEW ISSUER>>>>>>>>");
        Console.WriteLine("Enter the first name");
        regForm.FirstName = Console.ReadLine();
        Console.WriteLine("Enter the last name");
        regForm.LastName = Console.ReadLine();
        Console.WriteLine("Enter the email");
        regForm.Email = Console.ReadLine();
        Console.WriteLine("Enter the phone number");
        regForm.PhoneNumber = Console.ReadLine();
        Console.WriteLine("Enter the role name");
        regForm.RoleName = Console.ReadLine();
        await issuerService.CreateAsync(regForm);
    }
    public async Task GetUserByEmail(string email)
    {
        await issuerService.GetAsync(email);
    }

    public async Task Getall()
    {
        Console.Clear();
        Console.WriteLine("<<<<<<<<LIST OF THE ISSUERS>>>>>>>>");
        var issuers = await issuerService.GetallAsync();
        foreach (var issuer in issuers)
        {
            Console.WriteLine($"{issuer.FirstName}, {issuer.LastName}, {issuer.Email}, {issuer.PhoneNumber}, {issuer.RoleId}, {issuer.Role.Name}");
        }
    }
}
