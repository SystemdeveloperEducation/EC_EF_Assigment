namespace EF_CodeFirstApp.Models.Forms;

internal class ProductRegistrationForm
{
    public string ArticleNumber { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal StockPrice { get; set; }
    public string CategoryName { get; set; } = null!;
}
