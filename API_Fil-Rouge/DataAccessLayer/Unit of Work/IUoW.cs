using API_Fil_Rouge.DataAccessLayer.Interface;

namespace API_Fil_Rouge.DataAccessLayer.Unit_of_Work
{
    public interface IUoW
    {
        #region Repositories

        IRecetteRepository Recettes { get; }
        ICategorieRepository Categories { get; }
        IAvisRepository Avis { get; }
        IEtapeRepository Etapes { get; }
        IIngredientRepository Ingredients { get; }
        IUtilisateurRepository Utilisateurs { get; }


        #endregion

        #region Transactions

        bool HasActiveTransaction { get; }

        void BeginTransaction();
        void Commit();
        void Rollback();

        #endregion Transactions
    }
}
