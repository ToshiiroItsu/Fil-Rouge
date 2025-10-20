using API_Fil_Rouge.Models;
using Microsoft.Net.Http.Headers;
using System.Data;

namespace API_Fil_Rouge.DataAccessLayer.Session
{
    public interface IDBSession : IDisposable
    {
        DatabaseProviderName? DatabaseProviderName { get; }
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        bool HasActiveTransaction { get; }

        void BeginTransaction();
        void Commit();
        void Rollback();

    }
}
