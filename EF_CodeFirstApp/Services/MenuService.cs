using EF_CodeFirstApp.Models.Forms;

namespace EF_CodeFirstApp.Services;


public class Menu
{
    private readonly IssuerService issuerService = new IssuerService();
    public async Task CreateNow()
    {
        var regForm = new IssuerRegistrationForm
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "andres@gmail.com",
            PhoneNumber = "0703332221",
            RoleName = "Admin"
        };
        await issuerService.CreateAsync(regForm);
    }
}
