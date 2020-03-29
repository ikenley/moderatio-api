using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModaratioApi.Models
{
    public interface IRecipeService
    {
        Task<List<Recipe>> GetAllAsync();

        Task<Recipe> CreateAsync(Recipe recipeRequest);

        Task<Recipe> GetAsync(Guid id);

        Task<Recipe> UpdateAsync(Guid id, Recipe nextRecipe);

        Task<int> DeleteAsync(Guid id);
    }
}