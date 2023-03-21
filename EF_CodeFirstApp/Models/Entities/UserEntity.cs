using System.Collections.Generic;

namespace EF_CodeFirstApp.Models.Entities;

internal class UserEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    // tho code below says that an Issuer can have only one Role
    public int RoleId { get; set; }
    public RoleEntity Role { get; set; } = null!;
    public ICollection<IssueEntity> Issues { get; set; } = new HashSet<IssueEntity>();
}
