using API_Fil_Rouge.DataAccessLayer.Interface;
using API_Fil_Rouge.DataAccessLayer.Session;
using API_Fil_Rouge.Models.BO;
using Dapper;

namespace API_Fil_Rouge.DataAccessLayer.Repositories
{
    public class AvisRepository : IAvisRepository
    {
        const string AVIS_TABLE = "avis";
        readonly IDBSession _dBSession;

        public AvisRepository(IDBSession dBSession)
        {
            _dBSession = dBSession;
        }

        public async Task<List<Avis>> GetAvisByRecetteIdAsync(int idRecette)
        {
            String query = $"SELECT * FROM {AVIS_TABLE} WHERE idRecette = @idRecette";
            return (await _dBSession.Connection.QueryAsync<Avis>(query, new { idRecette }, transaction: _dBSession.Transaction)).ToList();
        }

        public async Task<int> CreateAvisAsync(Avis avis)
        {
            

           string query = $"INSERT INTO {AVIS_TABLE} (note, commentaire) VALUES(@note, @commentaire); RETURNING id";

            int result = await _dBSession.Connection.ExecuteAsync(query, new {avis}, transaction: _dBSession.Transaction);
            
            return result;
        }

        public async Task<int> DeleteAvisAsync(int id_recette, int id_utilisateur)
        {
            string query = $"DELETE * FROM {AVIS_TABLE} WHERE fk_recette = @id_recette AND fk_utilisateur = @id_utilisateur";
            int result = await _dBSession.Connection.ExecuteAsync(query, new {fk_recette = id_recette, fk_utilisateur = id_utilisateur}, transaction: _dBSession.Transaction);
            return result;
        }

        public async Task<List<Avis>> GetAllAvisAsync()
        {
            string query = $"SELECT * FROM {AVIS_TABLE}";
            return (await _dBSession.Connection.QueryAsync<Avis>(query, transaction: _dBSession.Transaction)).ToList();
        }


    }
}
