using API_Fil_Rouge.Models.BO;

namespace API_Fil_Rouge.DataAccessLayer.Interface
{
    public interface IAvisRepository
    {
        /// <summary>
        /// Retrieves all reviews from the database.
        /// </summary>
        /// <returns></returns>
        Task<List<Avis>> GetAllAvisAsync();

        /// <summary>
        /// Retrieves all reviews of a specific recipe by its ID
        /// </summary>
        /// <returns></returns>
        Task<List<Avis>> GetAvisByRecetteIdAsync(int idRecette);

        /// <summary>
        /// Create a new review in the datebase.
        /// </summary>
        /// <returns></returns>
        Task<int> CreateAvisAsync(Avis avis);

        /// <summary>
        /// Deletes a review from the datebase based on the recipe ID and user ID.
        /// </summary>
        /// <returns></returns>
        Task<int> DeleteAvisAsync(int id_recette, int id_utilisateur);
    }
}
