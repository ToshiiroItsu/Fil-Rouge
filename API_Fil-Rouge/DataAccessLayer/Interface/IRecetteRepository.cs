using API_Fil_Rouge.Models.BO;

namespace API_Fil_Rouge.DataAccessLayer.Interface
{
    public interface IRecetteRepository
    {

        #region Gestion Recette
        /// <summary>
        /// Récupère toutes les recettes de la base de données.
        /// </summary>
        /// <returns></returns>
        Task<List<Recette>> GetAllRecettesAsync();

        /// <summary>
        /// Récupère une recette spécifique par son ID.
        /// </summary>
        /// <returns></returns>
        Task<Recette> GetRecetteByIdAsync(int id);

        Task<IEnumerable<Recette>> GetRecetteByIdCategorieAsync(int idCategorie);

        /// <summary>
        /// Créez une nouvelle recette dans la base de données.
        /// </summary>
        /// <returns></returns>
        Task<Recette> CreateRecetteAsync(Recette recette);
        /// <summary>
        /// Met à jour une recette existante dans la base de données.
        /// </summary>
        /// <returns></returns>
        Task<Recette> UpdateRecetteAsync(Recette recette);

        /// <summary>
        /// Supprime une recette de la base de données en fonction de l'ID de recette.
        /// </summary>
        /// <returns></returns>
        Task<bool> DeleteRecetteAsync(int id);

        #endregion Gestion Recette

        #region Methods specific de RecetteRepository
        Task<bool> DeleteRecetteRelationsAsync(int idRecette);

        #endregion Methods specific de RecetteRepository
    }
}
