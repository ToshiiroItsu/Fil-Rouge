using API_Fil_Rouge.DataAccessLayer.Interface;
using API_Fil_Rouge.DataAccessLayer.Session;
using API_Fil_Rouge.Models.BO;
using Dapper;

namespace API_Fil_Rouge.DataAccessLayer.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        const string INGREDIENTS_TABLE = "ingredients";
        const string INGREDIENTS_RECETTES_TABLE = "ingredients_recettes";
        readonly IDBSession _dBSession;
        public IngredientRepository(IDBSession session)
        {
            _dBSession = session;
        }

        public async Task<List<Ingredient>> GetAllIngredientsAsync()
        {
            string query = $"SELECT * FROM {INGREDIENTS_TABLE}";
            return (await _dBSession.Connection.QueryAsync<Ingredient>(query, transaction: _dBSession.Transaction)).ToList();
        }

        public async Task<Ingredient> GetIngredientByIdAsync(int id)
        {
            string query = $"SELECT * FROM {INGREDIENTS_TABLE} WHERE id = @id";
            return await _dBSession.Connection.QuerySingleAsync<Ingredient>(query, new { id }, transaction: _dBSession.Transaction);
        }

        public async Task<Ingredient> CreateIngredientAsync(Ingredient ingredient)
        {
            string query = $"INSERT INTO {INGREDIENTS_TABLE}(nom) VALUES (@nom) RETURNING id";
            var Lastid = await _dBSession.Connection.ExecuteScalarAsync<int>(query, ingredient , transaction: _dBSession.Transaction);
            ingredient.id = Lastid;
            return ingredient;
        }

        public async Task<bool> DeleteIngredientAsync(int id)
        {
            string query = $"DELETE * FROM {INGREDIENTS_TABLE} WHERE id = @id ";

            int result = await _dBSession.Connection.ExecuteAsync(query, new { id }, transaction: _dBSession.Transaction);
            return result != 0;
        }

        public async Task<List<IngredientsRecette>> GetIngredientsWithQuantitiesOfRecetteIdAsync(int id)
        {
            string query = $"SELECT * FROM {INGREDIENTS_RECETTES_TABLE} WHERE fk_recette = @fk_recette ";
            return (await _dBSession.Connection.QueryAsync<IngredientsRecette>(query, new { fk_recette = id }, transaction: _dBSession.Transaction)).ToList();
        }

        public async Task<int> AddIngredientToRecetteAsync(int id_recette, Ingredient ingredient)
        {
            string query = $"INSERT INTO {INGREDIENTS_RECETTES_TABLE}(fk_ingredient, fk_recette) VALUES (@fk_ingredient, @fk_recette) ";
            int result = await
                _dBSession.Connection.ExecuteAsync(query, new { fk_ingredient = ingredient.id, fk_recette = id_recette }, transaction: _dBSession.Transaction);

            return result;
        }

        public async Task<bool> RemoveIngredientFromRecetteAsync(int id_recette, Ingredient ingredient)
        {
            string query = $"DELETE {INGREDIENTS_TABLE} FROM {INGREDIENTS_RECETTES_TABLE} WHERE fk_ingredient = @id AND fk_recette = @id_recette";
            int result = await _dBSession.Connection.ExecuteAsync(query, new { fk_ingredient = ingredient.id, fk_recette = id_recette }, transaction: _dBSession.Transaction);
            return result != 0;
        }
    }
}
