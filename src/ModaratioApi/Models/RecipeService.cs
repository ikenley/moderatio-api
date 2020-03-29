
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;

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

        public async Task<Recipe> GetAsync(Guid id)
        {
            return await _context.LoadAsync<Recipe>(id).ConfigureAwait(false);
        }

        // public async Task<List<Recipe>> GetAllAsync()
        // {
        //     //TODO this should probably be for a given AuthorId
        //     var scanConditions = new[] {
        //         new ScanCondition("Id", ScanOperator.IsNotNull, null)
        //     };
        //     var recipes = await _context.ScanAsync<Recipe>(scanConditions).GetRemainingAsync();
        //     recipes = recipes.Take(100).ToList();
        //     return recipes;
        // }

        public async Task<Recipe> UpdateAsync(Guid id, Recipe nextRecipe)
        {
            var prevRecipe = await GetAsync(id);
            var mergedRecipe = this.MergeRecipes(prevRecipe, nextRecipe);
            await _context.SaveAsync(mergedRecipe).ConfigureAwait(false);
            return mergedRecipe;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _context.DeleteAsync<Recipe>(id);
            return 0;
        }

        private Recipe MergeRecipes(Recipe a, Recipe b)
        {
            var mergedRecipe = new Recipe(
                name: b.Name ?? a.Name,
                description: b.Description ?? a.Description,
                url: b.Url ?? a.Url,
                imageSource: b.ImageSource ?? a.ImageSource,
                authorId: b.AuthorId ?? a.AuthorId
            );
            mergedRecipe.Id = a.Id;
            return mergedRecipe;
        }
    }
}