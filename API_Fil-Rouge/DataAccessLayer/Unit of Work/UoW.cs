using API_Fil_Rouge.DataAccessLayer.Interface;
using API_Fil_Rouge.DataAccessLayer.Session;

namespace API_Fil_Rouge.DataAccessLayer.Unit_of_Work
{
    public class UoW : IUoW
    {
        private readonly IDBSession _dbSession;
        private readonly Lazy<IRecetteRepository> _recettes;
        private readonly Lazy<ICategorieRepository> _categories;
        private readonly Lazy<IAvisRepository> _avis;
        private readonly Lazy<IEtapeRepository> _etapes;
        private readonly Lazy<IIngredientRepository> _ingredients;
        private readonly Lazy<IUtilisateurRepository> _utilisateurs;

        public UoW(IDBSession dbSession, IServiceProvider serviceProvider)
        {
            _dbSession = dbSession;
            _recettes = new Lazy<IRecetteRepository>(() => serviceProvider.GetRequiredService<IRecetteRepository>());
            _categories = new Lazy<ICategorieRepository>(() => serviceProvider.GetRequiredService<ICategorieRepository>());
            _avis = new Lazy<IAvisRepository>(() => serviceProvider.GetRequiredService<IAvisRepository>());
            _etapes = new Lazy<IEtapeRepository>(() => serviceProvider.GetRequiredService<IEtapeRepository>());
            _ingredients = new Lazy<IIngredientRepository>(() => serviceProvider.GetRequiredService<IIngredientRepository>());
            _utilisateurs = new Lazy<IUtilisateurRepository>(() => serviceProvider.GetRequiredService<IUtilisateurRepository>());
        }

        #region Repositories

        // ATTENTION : Les repositories doivent utiliser la transaction en cours dans
        // les requêtes Dapper

        public IRecetteRepository Recettes => _recettes.Value;

        public ICategorieRepository Categories => _categories.Value;
        public IAvisRepository Avis => _avis.Value;
        public IEtapeRepository Etapes => _etapes.Value;
        public IIngredientRepository Ingredients => _ingredients.Value;
        public IUtilisateurRepository Utilisateurs => _utilisateurs.Value;

        #endregion Repositories

        #region Transactions

        public bool HasActiveTransaction => _dbSession.HasActiveTransaction;

        public void BeginTransaction()
            => _dbSession.BeginTransaction();

        public void Commit()
            => _dbSession.Commit();

        public void Rollback()
            => _dbSession.Rollback();

        #endregion Transactions
    }
}
