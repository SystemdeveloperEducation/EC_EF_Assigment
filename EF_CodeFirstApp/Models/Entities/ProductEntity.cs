using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_CodeFirstApp.Models.Entities;

internal class ProductEntity
{
    [Key]
    public string ArticleNumber { get; set; } = null!;
    [Required]
    [Column(TypeName = "nvarchar(200)")]
    public string Name { get; set; } = null!;
    public string? Description { get; set; } = null!;

    [Required]
    [Column(TypeName = "money")] // this will change the type in the slq table to money
    public decimal StockPrice { get; set; } // but this will keep the decimal for the c# code
    // tho code below says that product can have only one category
    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!;
}
