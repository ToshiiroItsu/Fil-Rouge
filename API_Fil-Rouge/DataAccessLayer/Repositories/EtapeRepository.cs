using API_Fil_Rouge.DataAccessLayer.Interface;
using API_Fil_Rouge.DataAccessLayer.Session;
using API_Fil_Rouge.Models.BO;
using Dapper;

namespace API_Fil_Rouge.DataAccessLayer.Repositories
{
    public class EtapeRepository : IEtapeRepository
    {
        const string ETAPES_TABLE = "etapes";
        readonly IDBSession _dBSession;

        public async Task<List<Etape>> GetAllEtapesAsync()
        {
            string query = $"SELECT * FROM {ETAPES_TABLE}";
            return (await _dBSession.Connection.QueryAsync<Etape>(query, transaction: _dBSession.Transaction)).ToList();
        }

        public async Task<int> CreateEtapeAsync(Etape etape)
        {
            string query = $"INSERT INTO {ETAPES_TABLE} (numero, nom_etape, texte) VALUES (@numero, @nom_etape, @texte) RETURNING id";
            int newId = await
                _dBSession.Connection.ExecuteScalarAsync<int>(query, etape, transaction: _dBSession.Transaction);
            etape.numero = newId;
            return newId;
        }

        public async Task<bool> DeleteEtapeAsync(int id_recette, int numero)
        {
            string query = $"DELETE FROM {ETAPES_TABLE} WHERE numero = @numero AND fk_recette = @id_recette";
            int result = await _dBSession.Connection.ExecuteAsync(query, new { id_recette, numero}, transaction: _dBSession.Transaction);
            return result != 0;
        }
    }
}
