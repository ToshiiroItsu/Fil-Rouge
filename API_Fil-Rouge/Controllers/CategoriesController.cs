using API_Fil_Rouge.BusinessLogicLayer.Interfaces;
using API_Fil_Rouge.BusinessLogicLayer.Services;
using API_Fil_Rouge.Models.BO;
using API_Fil_Rouge.Models.DTO.Entre;
using API_Fil_Rouge.Models.DTO.Sortie;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace API_Fil_Rouge.Controllers
{
    /// <summary>
    /// Contrôleur API pour la gestion des Catégories.
    /// Permet de récupérer, créer, modifier et supprimer des Catégories.
    /// Accessible aux administrateurs.
    /// </summary>
    [Authorize(Policy = "UserOrAdmin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICookBookService _cookbookService;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="CategoriesController"/>.
        /// </summary>
        /// <param></param>
        public CategoriesController(ICookBookService cookbookService)
        {
            _cookbookService = cookbookService;
        }

        /// <summary>
        /// Récupère la liste de toute les Categories .
        /// </summary>
        /// <returns>
        /// Une action qui retourne la liste des Catégorie.
        /// </returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCategorie()
        {
            //1 - Je valide les entrées client (DTO Request)
            //2 - Je transforme le dto de request en un ou plusieurs BO
            //3 - J'apelle le ou les services avec les BO
            //4 - J'utilise le retour des services et je créé la réponse au client avec le DTO de Reponse

            //--3
            var categorie = await _cookbookService.GetAllCategoriesAsync();

            //--4
            IEnumerable<CategorieDTO> response = categorie.Select(a => new CategorieDTO()
            {
                id = a.id,
                nom = a.nom,
                
            });
            return Ok(response);
        }

        /// <summary>
        /// Récupère une catégorie par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant d'une catégorie.</param>
        /// <returns>
        /// La catégorie correspondant à l'identifiant, ou le code 404 si la catégorie n'existe pas.
        /// </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCategorieById([FromRoute] int id)
        {
            var categorie = await _cookbookService.GetCategorieByIdAsync(id);

            if (categorie is null)
                return NotFound();

            CategorieDTO response = new()
            {
                id = categorie.id,
                nom = categorie.nom,
            };

            return Ok(response);
        }


        /// <summary>
        /// Récupère une catégorie par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant d'une catégorie.</param>
        /// <returns>
        /// La catégorie correspondant à l'identifiant, ou le code 404 si la catégorie n'existe pas.
        /// </returns>
        [HttpGet("recette/{idRecette}/categories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async  Task<IActionResult> GetCategoriesByIdRecette([FromRoute] int idRecette)
        {
            var categories = await _cookbookService.GetCategoriesByIdRecetteAsync(idRecette);

            if (categories == null || !categories.Any())
                return NotFound();

            var response = categories.Select(c => new CategorieDTO
            {
                id = c.id,
                nom = c.nom,
            });

            return Ok(response);
        }



        [HttpPost("recette/{idRecette}/categories/{idCategorie}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostCategorieByIdRecette([FromRoute] int idRecette, [FromRoute] int idCategorie)
        {
            var result = await _cookbookService.PostCategorieByIdRecetteAsync(idCategorie, idRecette);

            if (!result)
                return BadRequest("Impossible d'ajouter cette catégorie à la recette.");

            return Ok("Catégorie ajoutée avec succès.");
        }


        [HttpDelete("recette/{idRecette}/categories/{idCategorie}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveCategorieByIdRecette([FromRoute] int idRecette, [FromRoute] int idCategorie)
        {
            var result = await _cookbookService.RemoveCategorieRecetteRelationshipAsync(idCategorie, idRecette);

            if (!result)
                return BadRequest("Impossible de retirer cette catégorie de la recette.");

            return Ok("Catégorie retirée avec succès.");
        }



        /// <summary>
        /// Crée une nouvel catégorie.
        /// </summary>
        /// <param name="validator">Validateur pour le modèle de création d'une catégorie.</param>
        /// <param name="request">Données de la catégorie à créer.</param>
        /// <returns>
        /// La catégorie créé, ou le code 400 en cas d'erreur.
        /// </returns>
        [Authorize(Roles = "Administrateur")]
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCategorie(IValidator<CreateCategorieDTO> validator, [FromBody] CreateCategorieDTO request)
        {
            validator.ValidateAndThrow(request);

            Categorie categorie = new()
            {
                
                nom = request.nom
            };

            var newCategorie = await _cookbookService.CreateCategorieAsync(categorie);

            if (newCategorie is null)
                return BadRequest("Invalid categorie data.");

            CategorieDTO response = new()
            {
                id = newCategorie.id,
                nom = newCategorie.nom

            };

            return CreatedAtAction(nameof(GetCategorieById), new { id = response.id }, response);
        }

        /// <summary>
        /// Met à jour une catégorie existante.
        /// </summary>
        /// <param name="validator">Validateur pour le modèle de mise à jour d'une catégorie.</param>
        /// <param name="id">Identifiant de la catégorie à mettre à jour.</param>
        /// <param name="request">Données mises à jour de la catégorie.</param>
        /// <returns>
        /// La catégorie mis à jour, ou le code 400 en cas d'erreur.
        /// </returns>
        [Authorize(Roles = "Administrateur")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCategorie(IValidator<ModifyCategorieDTO> validator, [FromRoute] int id, [FromBody] ModifyCategorieDTO request)
        {
            validator.ValidateAndThrow(request);

            Categorie categorie = new()
            {
                id = id,
                nom = request.nom,

            };

            var modifiedcategorie = await _cookbookService.UpdateCategorieAsync(categorie);

            if (modifiedcategorie is null)
                return BadRequest("Invalid categorie.");

            CategorieDTO response = new()
            {
                id = modifiedcategorie.id,
                nom = modifiedcategorie.nom,

            };

            return Ok(response);
        }

        /// <summary>
        /// Supprime une catégorie par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de la catégorie à supprimer.</param>
        /// <returns>
        /// Un code 204 si la suppression a réussi, ou 404 si la catégorie n'existe pas.
        /// </returns>
        [Authorize(Roles = "Administrateur")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCategorie([FromRoute] int id)
        {
            var success = await _cookbookService.DeleteCategorieAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
