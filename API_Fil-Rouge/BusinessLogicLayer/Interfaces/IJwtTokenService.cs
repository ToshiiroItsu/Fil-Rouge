namespace API_Fil_Rouge.BusinessLogicLayer.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(string username, params string[] roles);
    }
}
