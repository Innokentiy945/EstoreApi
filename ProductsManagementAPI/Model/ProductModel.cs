using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ProductsManagementAPI.Model;

[Table("Products")]
public class ProductModel
{
    [Key, ForeignKey("Id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid? Id { get; set; }

    [Required]
    public string? Description { get; set; }
    
    [Required]
    public double? Price { get; set; }
    
    [Required]
    public string Tags { get; set; }
}