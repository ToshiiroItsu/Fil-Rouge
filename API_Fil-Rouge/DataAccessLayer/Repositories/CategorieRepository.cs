using API_Fil_Rouge.DataAccessLayer.Interface;
using API_Fil_Rouge.DataAccessLayer.Session;
using API_Fil_Rouge.Models.BO;
using Dapper;
using System.Globalization;

namespace API_Fil_Rouge.DataAccessLayer.Repositories
{
    public class CategorieRepository : ICategorieRepository
    {
        const string CATEGORIES_TABLE = "categories";
        const string CATEGORIES_RECETTES_TABLE = "categories_recettes";
        readonly IDBSession _dBSession;
        public CategorieRepository(IDBSession session)
        {
            _dBSession = session;
        }
        #region Gestion catégorie

        public async Task<List<Categorie>> GetAllCategoriesAsync()
        {
            string query = $"SELECT * FROM {CATEGORIES_TABLE}";
            return (await _dBSession.Connection.QueryAsync<Categorie>(query, transaction: _dBSession.Transaction)).ToList();
        }

        public async Task<Categorie> GetCategorieByIdAsync(int id)
        {
            string query = $"SELECT * FROM {CATEGORIES_TABLE} WHERE id = @id";
            return await _dBSession.Connection.QuerySingleAsync<Categorie>(query, new { id }, transaction: _dBSession.Transaction);
        }

        public async Task<Categorie> CreateCategorieAsync(Categorie categorie)
        {
            string query = $"INSERT INTO {CATEGORIES_TABLE}(nom) VALUES (@nom) RETURNING id";
            var Lastid = await _dBSession.Connection.ExecuteScalarAsync<int>(query, categorie, transaction: _dBSession.Transaction);
            categorie.id = Lastid;

            return categorie;
        }

        public async Task<Categorie> UpdateCategorieAsync(Categorie categorie)
        {
            string query = $"UPDATE {CATEGORIES_TABLE} SET nom = @nom  WHERE id = @id";
            await _dBSession.Connection.ExecuteAsync(query, categorie, transaction: _dBSession.Transaction);
            return categorie;
        }

        public async Task<bool> DeleteCategorieAsync(int id)
        {
            string query = $"DELETE FROM {CATEGORIES_TABLE} WHERE id = @id ";

            int result = await _dBSession.Connection.ExecuteAsync(query, new { id }, transaction: _dBSession.Transaction);
            return result != 0;
        }

    #endregion Gestion catégorie

    #region Methods specific de CategorieRepository

        public async Task<bool> AddCategorieRecetteRelationshipAsync(int idCategorie, int idRecette)
        {
            string query = $"INSERT INTO {CATEGORIES_RECETTES_TABLE}(fk_categorie, fk_recette) VALUES(@idCategorie, @idRecette)";
            int numLine = await _dBSession.Connection.ExecuteAsync(query, new { idCategorie, idRecette }, transaction: _dBSession.Transaction);
            return numLine != 0;
        }

        public async Task<IEnumerable<Categorie>> GetCategoriesByIdRecetteAsync(int idRecette)
        {
            string query = $"SELECT c.* FROM {CATEGORIES_TABLE} c JOIN {CATEGORIES_RECETTES_TABLE} cr ON c.id = cr.fk_categorie WHERE cr.fk_recette = @idRecette";
            return await _dBSession.Connection.QueryAsync<Categorie>(query, new { idRecette }, transaction: _dBSession.Transaction);
        }

        
        public async Task<bool> RemoveCategorieRecetteRelationshipAsync(int idCategorie, int idRecette)
        {
            string query = $"DELETE FROM {CATEGORIES_RECETTES_TABLE} WHERE fk_recette = @idRecette AND fk_categorie = @idCategorie";
            int numLine = await _dBSession.Connection.ExecuteAsync(query, new { idRecette, idCategorie }, transaction: _dBSession.Transaction);
            return numLine != 0;
        }

        public async Task<bool> DeleteCategorieRelationsAsync(int idCategorie)
        {
            string query = $"DELETE FROM {CATEGORIES_RECETTES_TABLE} WHERE fk_categorie = @idCategorie";
            int numLine = await _dBSession.Connection.ExecuteAsync(query, new { idCategorie }, transaction: _dBSession.Transaction);
            return numLine != 0;
        }              

        public async Task<bool> GetCategorieExisteRecette(int id)
        {
            string query = $"SELECT count(*) FROM {CATEGORIES_RECETTES_TABLE} WHERE fk_categorie >= @id";
            int result = await _dBSession.Connection.ExecuteScalarAsync<int>(query, new { id }, transaction: _dBSession.Transaction);
            return result != 0;
        }

        #endregion Methods specific to BookRepository


    }
}
