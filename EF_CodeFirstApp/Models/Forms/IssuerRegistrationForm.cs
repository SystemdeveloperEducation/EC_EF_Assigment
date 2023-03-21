namespace EF_CodeFirstApp.Models.Forms;

public class IssueRegistrationForm
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string RoleName { get; set; } = null!;
    public string IssueDescription { get; set; } = null!;
}
