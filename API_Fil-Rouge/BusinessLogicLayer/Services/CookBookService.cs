using API_Fil_Rouge.BusinessLogicLayer.Interfaces;
using API_Fil_Rouge.DataAccessLayer.Session;
using API_Fil_Rouge.DataAccessLayer.Unit_of_Work;
using API_Fil_Rouge.Models.BO;
using API_Fil_Rouge.Models.DTO.Sortie;

namespace API_Fil_Rouge.BusinessLogicLayer.Services
{
    /// <summary>
    /// Service de gestion de le site de recettes.
    /// Fournit des méthodes pour gérer les recettes,les cataegorie, les etapes, avis, ingredient, les utilisateurs et leurs relations.
    /// </summary>
    public class CookBookService : ICookBookService
    {
        private readonly IUoW _UoW;
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="CookBookService"/>.
        /// </summary>
        /// <param name="UoW">Unité de travail pour accéder aux repositories.</param>
        public CookBookService(IUoW UoW)
        {
            _UoW = UoW;
        }
    

    #region Gestion des Recettes

        /// <summary>
        /// Récupère tous les Recettes.
        /// </summary>
        /// <returns>Une liste de recettes.</returns>
        public async Task<IEnumerable<Recette>> GetAllRecettesAsync()
        {
            return await _UoW.Recettes.GetAllRecettesAsync();
        }

        /// <summary>
        /// Récupère une recette par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de la recette.</param>
        /// <returns>La recette correspondant à l'identifiant.</returns>
        public async Task<Recette> GetRecetteByIdAsync(int id)
        {
            return await _UoW.Recettes.GetRecetteByIdAsync(id);
        }

        /// <summary>
        /// Ajoute une nouvelle recette.
        /// </summary>
        /// <param name="newRecette">Recette à ajouter.</param>
        /// <returns>La recette ajoutée.</returns>
        public async Task<Recette> CreateRecetteAsync(Recette newRecette)
        {
            return await _UoW.Recettes.CreateRecetteAsync(newRecette);
        }

        /// <summary>
        /// Modifie un recette existant.
        /// </summary>
        /// <param name="updateRecette">Recette à modifier.</param>
        /// <returns>Le recette modifié.</returns>
        public async Task<Recette> UpdateRecetteAsync(Recette updateRecette)
        {
            return await _UoW.Recettes.UpdateRecetteAsync(updateRecette);
        }

        /// <summary>
        /// Supprime un recette par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant du recette à supprimer.</param>
        /// <returns>Vrai si la suppression a réussi, sinon faux.</returns>
        public async Task<bool> DeleteRecetteAsync(int id)
        {
            return await _UoW.Recettes.DeleteRecetteAsync(id);
        }
        #endregion Gestion des recettes 

    #region Gestion des Categories

        /// <summary>
        /// Récupère toute les Catégories.
        /// </summary>
        /// <returns>Une liste de Catégories.</returns>
        public async Task<IEnumerable<Categorie>> GetAllCategoriesAsync()
        {
            return await _UoW.Categories.GetAllCategoriesAsync();
        }

        /// <summary>
        /// Récupère une Catégorie par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de la Catégorie.</param>
        /// <returns>La Catégorie correspondant à l'identifiant.</returns>
        public async Task<Categorie> GetCategorieByIdAsync(int id)
        {
            return await _UoW.Categories.GetCategorieByIdAsync(id);
        }

      


        /// <summary>
        /// Ajoute une nouvelle Catégorie.
        /// </summary>
        /// <param name="newAuthor">Catégorie à ajouter.</param>
        /// <returns>La Catégorie ajouté.</returns>
        public async Task<Categorie> CreateCategorieAsync(Categorie newCategorie)
        {
            return await _UoW.Categories.CreateCategorieAsync(newCategorie);
        }

        /// <summary>
        /// Modifie une Catégorie existante.
        /// </summary>
        /// <param name="updateAuthor">Catégorie à modifier.</param>
        /// <returns>Catégorie modifié.</returns>
        public async Task<Categorie> UpdateCategorieAsync(Categorie updateCategorie)
        {
            return await _UoW.Categories.UpdateCategorieAsync(updateCategorie);
        }

        /// <summary>
        /// Supprime une Catégorie par son identifiant.
        /// Cette méthode utilise une transaction pour garantir que toutes les opérations associées
        /// à la suppression de la Catégorie sont exécutées de manière atomique. Cela inclut la suppression
        /// des relations entre la Catégorie et les Recettes avant de supprimer la Catégorie elle-même.
        /// Si une étape échoue, la transaction n'est pas validée, garantissant ainsi l'intégrité des données.
        /// </summary>
        /// <param name="id">Identifiant de la Catégorie à supprimer.</param>
        /// <returns>Vrai si la suppression a réussi, sinon faux.</returns>
        public async Task<bool> DeleteCategorieAsync(int id)
        {
            _UoW.BeginTransaction();

            //vérifié que la categorie n'a pas de recette
            bool HasRelation = await _UoW.Categories.GetCategorieExisteRecette(id);

            if (HasRelation)
            {
                _UoW.Rollback();
                throw new InvalidOperationException("Impossible de supprimer la catégorie car elle est encore associée à des recettes.");
            }
            // Supprimer la catégorie
            var result = await _UoW.Categories.DeleteCategorieAsync(id);

            // Valide la transaction si la suppression a réussi
            if (result)
                _UoW.Commit();
            return result;



        }

        #endregion Gestion des Categories

    #region Gestion des relations entre Catégorie et Recette

        /// <summary>
        /// Récupère la liste des Categories associés à une recette.
        /// </summary>
        /// <returns>Liste des Catégories liés à la recette.</returns>
        public async Task<IEnumerable<Categorie>> GetCategoriesByIdRecetteAsync(int idRecette)
        {
            return await _UoW.Categories.GetCategoriesByIdRecetteAsync(idRecette);
        }

        /// <summary>
        /// Ajoute une catégorie à une recette.
        /// </summary>
        /// <param name="idRecette">ID de la recette.</param>
        /// <param name="idCategorie">ID de la catégorie à associer.</param>
        /// <returns>Booléen indiquant si l'opération a réussi.</returns>
        public async Task<bool> PostCategorieByIdRecetteAsync(int idRecette, int idCategorie)
        {
            return await _UoW.Categories.PostCategorieByIdRecetteAsync(idRecette, idCategorie);
        }

        /// <summary>
        /// Récupère la liste des Recettes associés à une Categorie.
        /// </summary>
        /// <returns>Liste des categories liés au recette.</returns>
        public async Task<IEnumerable<Recette>> GetRecetteByIdCategorieAsync(int idCategorie)
        {
            return await _UoW.Recettes.GetRecetteByIdCategorieAsync(idCategorie);
        }


        /// <summary>
        /// Ajoute une relation entre une categorie et une recette.
        /// </summary>
        /// <returns>Vrai si la relation a été ajoutée, sinon faux.</returns>
        public async Task<bool> AddCategorieRecetteRelationshipAsync(int idCategorie, int idRecette)
        {
            return await _UoW.Categories.AddCategorieRecetteRelationshipAsync(idCategorie, idRecette);
        }

        /// <summary>
        /// Supprime une relation entre une categorie et une recette .
        /// </summary>
        /// <returns>Vrai si la relation a été supprimée, sinon faux.</returns>
        public async Task<bool> RemoveCategorieRecetteRelationshipAsync(int idCategorie, int idRecette)
        {
            return await _UoW.Categories.RemoveCategorieRecetteRelationshipAsync(idCategorie, idRecette);
        }

        /// <summary>
        /// Supprime toutes les relations d'une catégorie avec des recettes.
        /// </summary>
        /// <returns>Vrai si les relations ont été supprimées, sinon faux.</returns>
        public async Task<bool> DeleteCategorieRelationsAsync(int idCategorie)
        {
            return await _UoW.Categories.DeleteCategorieRelationsAsync(idCategorie);
        }

        /// <summary>
        /// Supprime toutes les relations d'une recette avec des categories.
        /// </summary>
        /// <returns>Vrai si les relations ont été supprimées, sinon faux.</returns>
        public async Task<bool> DeleteRecetteRelationsAsync(int idRecette)
        {
            return await _UoW.Recettes.DeleteRecetteRelationsAsync(idRecette);
        }

        #endregion Gestion des relations entre Catégorie et Recettes

    #region Gestion des Ingredients

       public async Task<IEnumerable<Ingredient>> GetAllIngredientsAsync()
        {
            return await _UoW.Ingredients.GetAllIngredientsAsync();
        }

        public async Task<Ingredient> GetIngredientByIdAsync(int id)
        {
            return await _UoW.Ingredients.GetIngredientByIdAsync(id);
        }

       public async Task<Ingredient> CreateIngredientAsync(Ingredient ingredient)
        {
            return await _UoW.Ingredients.CreateIngredientAsync(ingredient);
        }

       public async Task<bool> DeleteIngredientAsync(int id)
        {
            return await _UoW.Ingredients.DeleteIngredientAsync(id);
        }




        public async Task<List<IngredientsRecette>> GetIngredientsWithQuantitiesOfRecetteIdAsync(int id)
        {
            return await _UoW.Ingredients.GetIngredientsWithQuantitiesOfRecetteIdAsync(id);
        }

        public async Task<int> AddIngredientToRecetteAsync(int id_recette, Ingredient ingredient)
        {
            return await _UoW.Ingredients.AddIngredientToRecetteAsync(id_recette, ingredient);
        }

        public async Task<bool> RemoveIngredientFromRecetteAsync(int id_recette, Ingredient ingredient)
        {
            return await _UoW.Ingredients.RemoveIngredientFromRecetteAsync(id_recette, ingredient);
        }
        #endregion Gestion des Ingredients

    #region Gestion des Etapes
        public async Task<List<Etape>> GetAllEtapesAsync()
        {
            return await _UoW.Etapes.GetAllEtapesAsync();
        }

        public async Task<int> CreateEtapeAsync(Etape etape)
        {
            return await _UoW.Etapes.CreateEtapeAsync(etape);
        }

        public async Task<bool> DeleteEtapeAsync(int id_recette, int numero)
        {
            return await _UoW.Etapes.DeleteEtapeAsync(id_recette, numero);
        }

        #endregion Gestion des Etapes

    }
}