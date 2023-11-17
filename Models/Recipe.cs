using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

public class Recipe
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }
    [Required(ErrorMessage = "Description is required")]
    public string Cuisine { get; set; }    
    public List<string> Ingredients { get; set; }
    public string Directions { get; set; }
    public DateTime CreatedDate { get; set; }

    public Recipe()
    {
        CreatedDate = DateTime.UtcNow;
    }
}