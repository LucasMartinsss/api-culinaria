using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using culinariaAPI.Models;
using culinariaAPI.Services;
using Microsoft.AspNetCore.Mvc;


namespace culinariaAPI.Controllers
{
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        
        /// <summary>
        /// Lista todas as receitas
        /// </summary>
        [HttpGet]
        public IEnumerable<Recipe> GetAll()
        {
            return RecipeService.recipes;
        }
        
        /// <summary>
        /// Retorna a receita pelo id
        /// </summary>
        /// <param name="id">Id da receita</param>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var recipe = RecipeService.recipes.FirstOrDefault(x => x.id == id);
            if (recipe != null)
            {
                return Ok(recipe);
            }

            return Ok("Receita não encontrada");
        }
        
        /// <summary>
        /// Adiciona uma nova receita
        /// </summary>
        [HttpPost]
        public IActionResult Post([FromBody]Recipe new_recipe)
        {
            var lastId = 0;
            if (RecipeService.recipes.Count > 0)
            {
               lastId = RecipeService.recipes.Max(x => x.id);
            }
            new_recipe.id = lastId + 1;
            new_recipe.ingredients = new List<Ingredient>();
            new_recipe.preparation = new Preparation();
            RecipeService.recipes.Add(new_recipe);

            return Ok(new_recipe);
        }
        
        /// <summary>
        /// Adiciona uma lista de ingredientes em uma receita
        /// </summary>
        /// <param name="id">Id da receita</param>
        [HttpPost("{id}/ingredients")]
        public IActionResult PostIngredient(int id, [FromBody]List<Ingredient> new_ingredients)
        {
            var recipe = RecipeService.recipes.FirstOrDefault(x => x.id == id);
            if (recipe != null)
            {
                var lastId = 0;
                if (RecipeService.ingredients.Count > 0)
                {
                    lastId = RecipeService.ingredients.Max(x => x.id);
                }
                foreach (Ingredient ingredient in new_ingredients)
                {
                    lastId++;
                    ingredient.id = lastId;
                    ingredient.recipe_id = id;
                }
                recipe.ingredients.AddRange(new_ingredients);
                RecipeService.ingredients.AddRange(new_ingredients);

                return Ok(new_ingredients);
            }

            return Ok("Não existe receita para inserir ingredientes!");
        }
        
        /// <summary>
        /// Adiciona um modo de preparo em uma receita
        /// </summary>
        /// <param name="id">Id da receita</param>
        [HttpPost("{id}/preparation")]
        public IActionResult PostPreparation(int id, [FromBody]Preparation new_preparation)
        {
            var recipe = RecipeService.recipes.FirstOrDefault(x => x.id == id);
            if (recipe != null)
            {
                var lastId = 0;
                if (RecipeService.preparations.Count > 0)
                {
                    lastId = RecipeService.preparations.Max(x => x.id);
                }
                new_preparation.id = lastId + 1;
                new_preparation.recipe_id = id;
                recipe.preparation = new_preparation;
                RecipeService.preparations.Add(new_preparation);

                return Ok(new_preparation);
            }
            return Ok("Não existe receita para inserir modo de preparo!");
        }
    }
}
