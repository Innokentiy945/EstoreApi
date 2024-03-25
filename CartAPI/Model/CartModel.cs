using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CartAPI.Model;

[Table("Cart")]
public class CartModel
{
    [Key, ForeignKey("Id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid? Id { get; set; }

    [Required]
    public string? Description { get; set; }
    
    [Required]
    public double? Price { get; set; }
}