using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModaratioApi.Models;
using Newtonsoft.Json;

namespace ModaratioApi.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class RecipesController : Controller
    {
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        // GET api/values
        [HttpGet]
        public async Task<List<Recipe>> Get()
        {
            var userId = HttpContext.GetUserId();
            return await _recipeService.GetAllAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Recipe> Get(Guid id)
        {
            var recipe = await _recipeService.GetAsync(id);
            return recipe;
        }

        // POST api/values
        [HttpPost]
        public async Task<Recipe> Post([FromBody] Recipe recipe)
        {
            var resultRecipe = await _recipeService.CreateAsync(recipe);
            return resultRecipe;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<Recipe> Put(Guid id, [FromBody] Recipe recipe)
        {
            var resultRecipe = await _recipeService.UpdateAsync(id, recipe);
            return resultRecipe;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<int> Delete(Guid id)
        {
            var statusCode = await _recipeService.DeleteAsync(id);
            return statusCode;
        }
    }
}
