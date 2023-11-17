using System;
using Microsoft.EntityFrameworkCore;

namespace RecipeAPI.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

        public DbSet<Recipe> Recipes { get; set; }
    }
}

