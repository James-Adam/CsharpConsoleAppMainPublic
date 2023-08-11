using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models;

public class Category
{
    [Key] //make data annotation primary key
    public int Id { get; set; }

    [Required] //make data annotation required key
    public string? Name { get; set; }

    [DisplayName("Display Order")]
    [Range(1, 100000, ErrorMessage = "Display Order must be between 1 and 100,000 only!!")]
    public int DisplayOrder { get; set; }

    public DateTime CreatedDateTime { get; set; } = DateTime.Now;
}