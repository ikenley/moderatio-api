
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace ModaratioApi.Models
{
    public class RecipeService : IRecipeService
    {
        private readonly IDynamoDBContext _context;

        public RecipeService(IDynamoDBContext context)
        {
            _context = context;
        }

        public async Task<Recipe> CreateAsync(Recipe recipeRequest)
        {
            var recipe = new Recipe("test", null, null, null, null);
            await _context.SaveAsync(recipe).ConfigureAwait(false);
            return recipe;
        }
    }
}