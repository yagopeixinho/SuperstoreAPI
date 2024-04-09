using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Superstore.Models;


[Table("Categories")]
public class Category
{
    public Category()
    {
        Products = new List<Product>();
    }

    [Key]
    public int CategoryId { get; set; }

    [Required]
    [StringLength(80)]
    public string? CategoryName { get; set; }

    [Required]
    [StringLength(300)]
    public string? ImageUrl { get; set; }

    // === Foreign Keys ===
    public ICollection<Product> Products { get; set; }
}
