using API_Fil_Rouge.DataAccessLayer.Interface;
using API_Fil_Rouge.DataAccessLayer.Repositories;
using API_Fil_Rouge.DataAccessLayer.Session;
using API_Fil_Rouge.DataAccessLayer.Session.PostGres;
using API_Fil_Rouge.DataAccessLayer.Unit_of_Work;
using API_Fil_Rouge.Models;

namespace API_Fil_Rouge.DataAccessLayer
{
    public static class DalExtended
    {
        public static void AddDal(this IServiceCollection services, IDatabaseSettings settings)
        {
            services.AddScoped<IDBSession, PostGresDBSession>();

            services.AddScoped<IUoW, UoW>();

            //Repositorie
            services.AddTransient<ICategorieRepository, CategorieRepository>();
            services.AddTransient<IRecetteRepository, RecetteRepository>();
            services.AddTransient<IIngredientRepository, IngredientRepository>();
            services.AddTransient<IEtapeRepository, EtapeRepository>();

        }
    }
}
