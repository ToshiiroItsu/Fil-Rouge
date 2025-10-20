using API_Fil_Rouge.Models.BO;

namespace API_Fil_Rouge.DataAccessLayer.Interface
{
    public interface IUtilisateurRepository
    {
        /// <summary>
        /// Retrieves all user from the database.
        /// </summary>
        /// <returns></returns>
        Task<List<Utilisateur>> GetAllUtilisateursAsync();

        /// <summary>
        /// Retrieves an user recipe by its ID
        /// </summary>
        /// <returns></returns>
        Task<List<Utilisateur>> GetUtilisateurByIdAsync(int id);

        /// <summary>
        /// Create a new user in the datebase.
        /// </summary>
        /// <returns></returns>
        Task<int> CreateUtilisateurAsync(Utilisateur utilisateur);

        /// <summary>
        /// Deletes an user from the datebase based on the user ID.
        /// </summary>
        /// <returns></returns>
        Task<int> DeleteUtilisateurAsync(int id);
    }
}
