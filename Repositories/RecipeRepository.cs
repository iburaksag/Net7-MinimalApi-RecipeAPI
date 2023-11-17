using RecipeAPI.Data;

public class RecipeRepository
{
    private readonly ApplicationDbContext _context;

    public RecipeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Recipe> GetAllRecipes() => _context.Recipes.ToList();
    public Recipe GetRecipeById(int id) => _context.Recipes.FirstOrDefault(r => r.Id == id);

    public void AddRecipe(Recipe recipe)
    {
        recipe.Id = _context.Recipes.Count() + 1;
        _context.Recipes.Add(recipe);
        _context.SaveChanges();
    }

    public void UpdateRecipe(int id, Recipe updatedRecipe)
    {
        var existingRecipe = _context.Recipes.FirstOrDefault(r => r.Id == id);
        if (existingRecipe != null)
        {
            existingRecipe.Title = updatedRecipe.Title;
            existingRecipe.Cuisine = updatedRecipe.Cuisine;
            existingRecipe.Ingredients = updatedRecipe.Ingredients;
            existingRecipe.Directions = updatedRecipe.Directions;
        }

        _context.SaveChanges();
    }

    public void DeleteRecipe(int id)
    {
        var recipeToRemove = _context.Recipes.FirstOrDefault(r => r.Id == id);
        if (recipeToRemove != null)
        {
            _context.Recipes.Remove(recipeToRemove);
        }

        _context.SaveChanges();
    }
}
