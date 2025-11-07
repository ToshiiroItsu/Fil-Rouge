using API_Fil_Rouge.Models.BO;
using API_Fil_Rouge.Models.DTO.Sortie;

namespace API_Fil_Rouge.BusinessLogicLayer.Interfaces
{
    public interface ICookBookService
    {
    #region Gestion des Categories

        Task<IEnumerable<Categorie>> GetAllCategoriesAsync();
        Task<Categorie> GetCategorieByIdAsync(int id);
        Task<Categorie> CreateCategorieAsync(Categorie newCategorie);
        Task<Categorie> UpdateCategorieAsync(Categorie updateCategorie);
        Task<bool> DeleteCategorieAsync(int id);

    #endregion Gestion des Categories

    #region Gestion des Recettes

        Task<IEnumerable<Recette>> GetAllRecettesAsync();
        Task<Recette> GetRecetteByIdAsync(int id);
        Task<Recette> CreateRecetteAsync(Recette newRecette);
        Task<Recette> UpdateRecetteAsync(Recette updateRecette);
        Task<bool> DeleteRecetteAsync(int id);

    #endregion Gestion des Recettes

    #region Gestion des relations entre Catégorie et Recette

        Task<IEnumerable<Categorie>> GetCategoriesByIdRecetteAsync(int idRecette);
        Task<bool> PostCategorieByIdRecetteAsync(int idRecette, int idCategorie);
        Task<IEnumerable<Recette>> GetRecetteByIdCategorieAsync(int idCategorie);
        Task<bool> AddCategorieRecetteRelationshipAsync(int idCategorie, int idRecette);
        Task<bool> RemoveCategorieRecetteRelationshipAsync(int idCategorie, int idRecette);
        Task<bool> DeleteCategorieRelationsAsync(int idCategorie);
        Task<bool> DeleteRecetteRelationsAsync(int idRecette);

        #endregion Gestion des relations entre Catégorie et Recette

    #region Gestion des Ingredients

        Task<IEnumerable<Ingredient>> GetAllIngredientsAsync();

        Task<Ingredient> GetIngredientByIdAsync(int id);
        Task<Ingredient> CreateIngredientAsync(Ingredient ingredient);
        Task<bool> DeleteIngredientAsync(int id);
        Task<List<IngredientsRecette>> GetIngredientsWithQuantitiesOfRecetteIdAsync(int id);
        Task<int> AddIngredientToRecetteAsync(int id_recette, Ingredient ingredient);
        Task<bool> RemoveIngredientFromRecetteAsync(int id_recette, Ingredient ingredient);


        #endregion Gestion des Ingredients

    #region Gestion des Etapes

        Task<List<Etape>> GetAllEtapesAsync();
        Task<int> CreateEtapeAsync(Etape etape);
        Task<bool> DeleteEtapeAsync(int id_recette, int numero);
        #endregion Gestion des Etapes




    }
}
