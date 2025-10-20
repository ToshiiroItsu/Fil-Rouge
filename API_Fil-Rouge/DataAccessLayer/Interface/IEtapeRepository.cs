using API_Fil_Rouge.Models.BO;

namespace API_Fil_Rouge.DataAccessLayer.Interface
{
    public interface IEtapeRepository
    {
        /// <summary>
        /// Retrieves all step from the database.
        /// </summary>
        /// <returns></returns>
        Task<List<Etape>> GetAllEtapesAsync();

        /// <summary>
        /// Create a new step in the datebase.
        /// </summary>
        /// <returns></returns>
        Task<int> CreateEtapeAsync(Etape etape);

        /// <summary>
        /// Deletes a categorie from the datebase based on the recipe ID and user ID.
        /// </summary>
        /// <returns></returns>
        Task<bool> DeleteEtapeAsync(int id_recette, int numero);

    }
}
