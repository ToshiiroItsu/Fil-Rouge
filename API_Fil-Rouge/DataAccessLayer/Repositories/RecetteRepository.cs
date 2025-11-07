using API_Fil_Rouge.DataAccessLayer.Interface;
using API_Fil_Rouge.DataAccessLayer.Session;
using API_Fil_Rouge.Models.BO;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace API_Fil_Rouge.DataAccessLayer.Repositories
{
    public class RecetteRepository : IRecetteRepository
    {
        const string RECETTES_TABLE = "recettes";
        const string RECETTES_CATEGORIES_TABLE = "categories_recetttes";
        readonly IDBSession _dBSession;

        public RecetteRepository(IDBSession session)
        {
            _dBSession = session;
        }
        #region Gestion des Recettes
        public async Task<List<Recette>> GetAllRecettesAsync()
        {
            string query = $"SELECT * FROM {RECETTES_TABLE}";
            return (await _dBSession.Connection.QueryAsync<Recette>(query, transaction: _dBSession.Transaction)).ToList();
        }

        public async Task<Recette> GetRecetteByIdAsync(int id)
        {
            string query = $"SELECT * FROM {RECETTES_TABLE} WHERE id = @id";
            return await _dBSession.Connection.QuerySingleAsync<Recette>(query, new { id }, transaction: _dBSession.Transaction);
        }

        public async Task<IEnumerable<Recette>> GetRecetteByIdCategorieAsync(int idCategorie)
        {

            string query = $"SELECT r.* FROM {RECETTES_TABLE} r JOIN {RECETTES_CATEGORIES_TABLE} rc ON r.id = rc.fk_recette WHERE rc.fk_categorie = @idCategorie";
            return await _dBSession.Connection.QueryAsync<Recette>(query, new { idCategorie }, transaction: _dBSession.Transaction);
        }


        public async Task<Recette> CreateRecetteAsync(Recette recette)
        {
            string query = $"INSERT INTO {RECETTES_TABLE} (nom, temps_preparation, temps_cuisson, difficulte, cout, description, nombrepersonne, image) VALUES (@nom, @temps_preparation, @temps_cuisson, @difficulte, @cout, @description, @nombrepersonne, @image) RETURNING id";
            var Lastid = await
                _dBSession.Connection.ExecuteScalarAsync<int>(query, recette, transaction: _dBSession.Transaction);
            recette.id = Lastid;
            return recette;

        }

        public async Task<Recette> UpdateRecetteAsync(Recette recette)
        {
            string query = $"UPDATE {RECETTES_TABLE} SET nom = @nom, description = @description, temps_preparation = @temps_preparation, temps_cuisson = @temps_cuisson, difficulte = @difficulte, image = @image, cout = @cout, nombrepersonne = @nombrepersonne, fk_utilisateur = @fk_utilisateur WHERE id = @id";
            await _dBSession.Connection.ExecuteAsync(query, recette, transaction: _dBSession.Transaction);
            return recette;
        }

        public async Task<bool> DeleteRecetteAsync(int id)
        {
            string query = $"DELETE FROM {RECETTES_TABLE} WHERE id = @id";
            int result = await _dBSession.Connection.ExecuteAsync(query, new { id }, transaction: _dBSession.Transaction);
            return result != 0;
        }
        #endregion Gestion des Recettes

        #region Methods specific de RecetteRepository
        public async Task<bool> DeleteRecetteRelationsAsync(int idRecette)
        {
            string query = $"DELETE FROM {RECETTES_CATEGORIES_TABLE} WHERE fk_recette = @idRecette";
            int numLine = await _dBSession.Connection.ExecuteAsync(query, new { idRecette }, transaction: _dBSession.Transaction);
            return numLine != 0;
        }
        #endregion Methods specific to RecetteRepository
    }
}
