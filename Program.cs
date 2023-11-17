using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeAPI.Data;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddTransient<RecipeRepository>();

var app = builder.Build();

app.MapGet("/recipes", ([FromServices] RecipeRepository repository) => repository.GetAllRecipes());

app.MapGet("/recipes/{id}", ([FromServices] RecipeRepository repository, int id) => repository.GetRecipeById(id));

app.MapPost("/recipes", ([FromServices] RecipeRepository repository, Recipe recipe) =>
{
    repository.AddRecipe(recipe);
    return Results.Ok(recipe);
});

app.MapPut("/recipes/{id}", ([FromServices] RecipeRepository repository, int id, Recipe updatedRecipe) =>
{
    repository.UpdateRecipe(id, updatedRecipe);
    return Results.Ok(updatedRecipe);
});

app.MapDelete("/recipes/{id}", ([FromServices] RecipeRepository repository, int id) =>
{
    repository.DeleteRecipe(id);
    return Results.Ok();
});

app.Run();
