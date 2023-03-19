using System.Collections.Generic;

namespace EF_CodeFirstApp.Models.Entities;

internal class IssueEntity
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
    // the code down translate to : IssueEntity can be have association with many Issuers
    public DateTime CreatedAt { get; set; }
    public int IssuerId { get; set; }
    public IssuersEntity Issuer { get; set; } = null!;
}
