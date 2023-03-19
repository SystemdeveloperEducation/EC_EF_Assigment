namespace EF_CodeFirstApp.Models.Forms;

public class IssuerRegistrationForm
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string RoleName { get; set; } = null!;
}
