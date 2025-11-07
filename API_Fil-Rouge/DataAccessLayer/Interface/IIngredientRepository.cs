using API_Fil_Rouge.Models.BO;

namespace API_Fil_Rouge.DataAccessLayer.Interface
{
    public interface IIngredientRepository
    {
        /// <summary>
        /// Retrieves all ingredients from the database.
        /// </summary>
        /// <returns></returns>
        Task<List<Ingredient>> GetAllIngredientsAsync();

        Task<Ingredient> GetIngredientByIdAsync(int id);

        /// <summary>
        /// Create a new ingredient in the datebase.
        /// </summary>
        /// <returns></returns>
        Task<Ingredient> CreateIngredientAsync(Ingredient ingredient);

        /// <summary>
        /// Deletes an ingredient from the datebase based on the recipe ID and user ID.
        /// </summary>
        /// <returns></returns>
        Task<bool> DeleteIngredientAsync(int id);

        /// <summary>
        /// Retrieves all ingredients of a specific recipe by its ID
        /// </summary>
        /// <returns></returns>
        Task<List<IngredientsRecette>> GetIngredientsWithQuantitiesOfRecetteIdAsync(int id);

        /// <summary>
        /// Add an ingredient to a recipe from the database.
        /// </summary>
        /// <returns></returns>
        Task<int> AddIngredientToRecetteAsync(int id_recette, Ingredient ingredient);

        /// <summary>
        /// Remove an ingredient from a recipe from the database
        /// </summary>
        /// <returns></returns>
        Task<bool> RemoveIngredientFromRecetteAsync(int id_recette, Ingredient ingredient);
    }
}
