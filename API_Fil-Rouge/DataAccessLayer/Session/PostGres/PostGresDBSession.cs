using API_Fil_Rouge.Models;
using Npgsql;

namespace API_Fil_Rouge.DataAccessLayer.Session.PostGres
{
    public class PostGresDBSession : BaseSession
    {
        public PostGresDBSession(IDatabaseSettings settings)
        {
            Connection = new NpgsqlConnection(settings.ConnectionString);
            DatabaseProviderName = settings.DatabaseProviderName;
        }
    }
}
