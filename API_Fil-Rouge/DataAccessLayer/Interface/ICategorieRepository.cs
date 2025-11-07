using API_Fil_Rouge.Models.BO;

namespace API_Fil_Rouge.DataAccessLayer.Interface
{
    public interface ICategorieRepository
    {

    #region Gestion catégorie
        /// <summary>
        /// Récupère toutes les catégories de la base de données.
        /// </summary>
        /// <returns></returns>
        Task<List<Categorie>> GetAllCategoriesAsync();

        /// <summary>
        /// Récupère une Catégorie spécifique par son ID
        /// </summary>
        /// <returns></returns>
        Task<Categorie> GetCategorieByIdAsync(int id);


        /// <summary>
        /// Créez une nouvelle catégorie dans la base de données.
        /// </summary>
        /// <returns></returns>
        Task<Categorie> CreateCategorieAsync(Categorie categorie);

        /// <summary>
        /// Met à jour une Catégorie existante dans la base de données.
        /// </summary>
        /// <returns></returns>
        Task<Categorie> UpdateCategorieAsync(Categorie categorie);

        /// <summary>
        /// Supprime une catégorie de la base de données en fonction de l'ID de recette et de l'ID utilisateur.
        /// </summary>
        /// <returns></returns>
        Task<bool> DeleteCategorieAsync(int id);

        #endregion Gestion catégorie
    #region Methods specific de CategorieRepository

        Task<bool> AddCategorieRecetteRelationshipAsync(int idCategorie, int idRecette);

        Task<IEnumerable<Categorie>> GetCategoriesByIdRecetteAsync(int idRecette);

        Task<bool> RemoveCategorieRecetteRelationshipAsync(int idCategorie, int idRecette);

        Task<bool> DeleteCategorieRelationsAsync(int idCategorie);

        Task<bool> GetCategorieExisteRecette(int id);
        Task<bool> PostCategorieByIdRecetteAsync(int idRecette, int idCategorie);


        #endregion Methods specific to BookRepository
    }
}
