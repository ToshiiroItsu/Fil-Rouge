using API_Fil_Rouge.BusinessLogicLayer.Interfaces;
using API_Fil_Rouge.BusinessLogicLayer.Services;

namespace API_Fil_Rouge.BusinessLogicLayer
{
    public static class ServiceExt
    {
        public static void AddBll(this IServiceCollection services)
        {
            services.AddTransient<ICookBookService, CookBookService>();
            services.AddTransient<IJwtTokenService, JwtTokenService>();
        }
    }
}
