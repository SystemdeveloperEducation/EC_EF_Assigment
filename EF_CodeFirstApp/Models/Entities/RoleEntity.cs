using System.Collections.Generic;

namespace EF_CodeFirstApp.Models.Entities;

internal class RoleEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    // the code down translate to : RoleEntity can be have association with many Issuers
    public ICollection<IssuersEntity> Issuers { get; set; } = new HashSet<IssuersEntity>(); // hashset is a collection of unique items
}
