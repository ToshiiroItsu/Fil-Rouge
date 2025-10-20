using API_Fil_Rouge.BusinessLogicLayer.Interfaces;
using API_Fil_Rouge.BusinessLogicLayer.Services;
using API_Fil_Rouge.Models.BO;
using API_Fil_Rouge.Models.DTO.Entre;
using API_Fil_Rouge.Models.DTO.Sortie;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Fil_Rouge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly ICookBookService _cookbookService;
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="IngredientsController"/>.
        /// </summary>
        /// <param></param>
        public IngredientsController(ICookBookService cookbookService)
        {
            _cookbookService = cookbookService;
        }

        /// <summary>
        /// Récupère la liste de tout les Ingredients .
        /// </summary>
        /// <returns>
        /// Une action qui retourne la liste des Ingredients.
        /// </returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetIngredient()
        {
            //1 - Je valide les entrées client (DTO Request)
            //2 - Je transforme le dto de request en un ou plusieurs BO
            //3 - J'apelle le ou les services avec les BO
            //4 - J'utilise le retour des services et je créé la réponse au client avec le DTO de Reponse

            //--3
            var ingredient = await _cookbookService.GetAllIngredientsAsync();

            //--4
            IEnumerable<IngredientDTO> response = ingredient.Select(a => new IngredientDTO()
            {
                id = a.id,
                nom = a.nom,
                quantite = a.quantite

            });
            return Ok(response);
        }

        /// <summary>
        /// Récupère un Ingredient par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant d'un Ingredient.</param>
        /// <returns>
        /// L'Ingredient correspondant à l'identifiant, ou le code 404 si l'Ingredient n'existe pas.
        /// </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetIngredientById([FromRoute] int id)
        {
            var ingredient = await _cookbookService.GetIngredientByIdAsync(id);

            if (ingredient is null)
                return NotFound();

            IngredientDTO response = new()
            {
                id = ingredient.id,
                nom = ingredient.nom,
                quantite = ingredient.quantite
            };

            return Ok(response);
        }

        /// <summary>
        /// Crée un nouveau Ingredient.
        /// </summary>
        /// <param name="validator">Validateur pour le modèle de création d'un Ingredient.</param>
        /// <param name="request">Données de l'Ingredient à créer.</param>
        /// <returns>
        /// L'Ingredient créé, ou le code 400 en cas d'erreur.
        /// </returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateIngredient(IValidator<CreateIngredientDTO> validator, [FromBody] CreateIngredientDTO request)
        {
            validator.ValidateAndThrow(request);

            Ingredient ingredient = new()
            {

                nom = request.nom,
                quantite = request.quantite
                
            };

            var newIngredient = await _cookbookService.CreateIngredientAsync(ingredient);

            if (newIngredient is null)
                return BadRequest("Invalid ingredient data.");

            IngredientDTO response = new()
            {
                id = newIngredient.id,
                nom = newIngredient.nom,
                quantite = newIngredient.quantite

            };

            return CreatedAtAction(nameof(GetIngredientById), new { id = response.id }, response);
        }

        ///// <summary>
        ///// Met à jour une catégorie existante.
        ///// </summary>
        ///// <param name="validator">Validateur pour le modèle de mise à jour d'une catégorie.</param>
        ///// <param name="id">Identifiant de la catégorie à mettre à jour.</param>
        ///// <param name="request">Données mises à jour de la catégorie.</param>
        ///// <returns>
        ///// La catégorie mis à jour, ou le code 400 en cas d'erreur.
        ///// </returns>
        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> UpdateCategorieAsync(IValidator<ModifyCategorieDTO> validator, [FromRoute] int id, [FromBody] ModifyCategorieDTO request)
        //{
        //    validator.ValidateAndThrow(request);

        //    Categorie categorie = new()
        //    {
        //        id = id,
        //        nom = request.nom,

        //    };

        //    var modifiedcategorie = await _cookbookService.UpdateCategorieAsync(categorie);

        //    if (modifiedcategorie is null)
        //        return BadRequest("Invalid categorie.");

        //    CategorieDTO response = new()
        //    {
        //        id = modifiedcategorie.id,
        //        nom = modifiedcategorie.nom,

        //    };

        //    return Ok(response);
        //}

        /// <summary>
        /// Supprime un Ingredient par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de l'Ingredient à supprimer.</param>
        /// <returns>
        /// Un code 204 si la suppression a réussi, ou 404 si l'Ingredient n'existe pas.
        /// </returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteIngredient([FromRoute] int id)
        {
            var success = await _cookbookService.DeleteIngredientAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
