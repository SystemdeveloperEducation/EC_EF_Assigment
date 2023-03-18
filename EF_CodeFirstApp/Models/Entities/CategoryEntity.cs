using System.Collections.Generic;

namespace EF_CodeFirstApp.Models.Entities;

internal class CategoryEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    // the code down translate to : CategoryEntity can be a part of many ProductEntity
    // can have an association to many products
    public ICollection<ProductEntity> Products { get; set; } = new HashSet<ProductEntity>(); // hashset is a collection of unique items
}
