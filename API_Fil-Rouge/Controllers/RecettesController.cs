using API_Fil_Rouge.BusinessLogicLayer.Interfaces;
using API_Fil_Rouge.Models.BO;
using API_Fil_Rouge.Models.DTO.Entre;
using API_Fil_Rouge.Models.DTO.Sortie;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Fil_Rouge.Controllers
{
    [Authorize(Policy = "UserOrAdmin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RecettesController : ControllerBase
    {
        private readonly ICookBookService _cookbookService;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="RecettesController"/>.
        /// </summary>
        /// <param></param>
        public RecettesController(ICookBookService cookbookService)
        {
            _cookbookService = cookbookService;
        }

        /// <summary>
        /// Récupère la liste de toute les Recettes.
        /// </summary>
        /// <returns>
        /// Une action qui retourne la liste des Recettes.
        /// </returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRecette()
        {
            //1 - Je valide les entrées client (DTO Request)
            //2 - Je transforme le dto de request en un ou plusieurs BO
            //3 - J'apelle le ou les services avec les BO
            //4 - J'utilise le retour des services et je créé la réponse au client avec le DTO de Reponse

            //--3
            var recette = await _cookbookService.GetAllRecettesAsync();

            //--4
            IEnumerable<RecetteDTO> response = recette.Select(a => new RecetteDTO()
            {
                id = a.id,
                nom = a.nom,
                temps_preparation = a.temps_preparation,
                temps_cuisson = a.temps_cuisson,
                difficulte = a.difficulte,
                cout = a.cout,
                description = a.description,
                nombrepersonne = a.nombrepersonne,
                fk_utilisateur = a.fk_utilisateur

            });
            return Ok(response);
        }

        /// <summary>
        /// Récupère une Recette par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant d'une Recette.</param>
        /// <returns>
        /// La Recette correspondant à l'identifiant, ou le code 404 si la catégorie n'existe pas.
        /// </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRecetteById([FromRoute] int id)
        {
            var recette = await _cookbookService.GetRecetteByIdAsync(id);

            if (recette is null)
                return NotFound();

            RecetteDTO response = new()
            {
                id = recette.id,
                nom = recette.nom,
                temps_preparation = recette.temps_preparation,
                temps_cuisson = recette.temps_cuisson,
                difficulte = recette.difficulte,
                cout = recette.cout,
                description = recette.description,
                nombrepersonne = recette.nombrepersonne,
                fk_utilisateur = recette.fk_utilisateur
            };

            return Ok(response);
        }

        /// <summary>
        /// Crée une nouvelle Recette.
        /// </summary>
        /// <param name="validator">Validateur pour le modèle de création d'une Recette.</param>
        /// <param name="request">Données de la Recette à créer.</param>
        /// <returns>
        /// La Recette créé, ou le code 400 en cas d'erreur.
        /// </returns>
        [Authorize(Roles = "Administrateur")]
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateRecette(IValidator<CreateRecetteDTO> validator, [FromBody] CreateRecetteDTO request)
        {
            validator.ValidateAndThrow(request);

            Recette recette = new()
            {

                nom = request.nom,
                temps_preparation = request.temps_preparation,
                temps_cuisson = request.temps_cuisson,
                difficulte = request.difficulte,
                cout = request.cout,
                description = request.description,
                nombrepersonne = request.nombrepersonne,
                fk_utilisateur = request.fk_utilisateur
            };

            var newRecette = await _cookbookService.CreateRecetteAsync(recette);

            if (newRecette is null)
                return BadRequest("Invalid recette data.");

            RecetteDTO response = new()
            {
                id = newRecette.id,
                nom = newRecette.nom,
                temps_preparation = newRecette.temps_preparation,
                temps_cuisson = newRecette.temps_cuisson,
                difficulte = newRecette.difficulte,
                cout = newRecette.cout,
                description = newRecette.description,
                nombrepersonne = newRecette.nombrepersonne,
                fk_utilisateur = newRecette.fk_utilisateur
            };

            return CreatedAtAction(nameof(GetRecetteById), new { id = response.id }, response);
        }

        /// <summary>
        /// Met à jour une Recette existante.
        /// </summary>
        /// <param name="validator">Validateur pour le modèle de mise à jour d'une Recette.</param>
        /// <param name="id">Identifiant de la Recette à mettre à jour.</param>
        /// <param name="request">Données mises à jour de la Recette.</param>
        /// <returns>
        /// La Recette mis à jour, ou le code 400 en cas d'erreur.
        /// </returns>
        [Authorize(Roles = "Administrateur")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateRecette(IValidator<ModifyRecetteDTO> validator, [FromRoute] int id, [FromBody] ModifyRecetteDTO request)
        {
            validator.ValidateAndThrow(request);

            Recette recette = new()
            {
                id = id,
                nom = request.nom,
                temps_preparation = request.temps_preparation,
                temps_cuisson = request.temps_cuisson,
                difficulte = request.difficulte,
                cout = request.cout,
                description = request.description,
                nombrepersonne = request.nombrepersonne,
                fk_utilisateur = request.fk_utilisateur

            };

            var modifiedrecette = await _cookbookService.UpdateRecetteAsync(recette);

            if (modifiedrecette is null)
                return BadRequest("Invalid recette.");

            RecetteDTO response = new()
            {
                id = modifiedrecette.id,
                nom = modifiedrecette.nom,
                temps_preparation = modifiedrecette.temps_preparation,
                temps_cuisson = modifiedrecette.temps_cuisson,
                difficulte = modifiedrecette.difficulte,
                cout = modifiedrecette.cout,
                description = modifiedrecette.description,
                nombrepersonne = modifiedrecette.nombrepersonne,
                fk_utilisateur = modifiedrecette.fk_utilisateur
            };

            return Ok(response);
        }

        /// <summary>
        /// Supprime une Recette par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de la Recette à supprimer.</param>
        /// <returns>
        /// Un code 204 si la suppression a réussi, ou 404 si la Recette n'existe pas.
        /// </returns>
        [Authorize(Roles = "Administrateur")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRecette([FromRoute] int id)
        {
            var success = await _cookbookService.DeleteRecetteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
