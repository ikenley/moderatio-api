using System.Threading.Tasks;

namespace ModaratioApi.Models
{
    public interface IRecipeService
    {
        Task<Recipe> CreateAsync(Recipe recipeRequest);
    }
}