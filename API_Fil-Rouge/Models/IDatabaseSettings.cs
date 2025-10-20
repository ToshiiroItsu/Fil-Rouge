namespace API_Fil_Rouge.Models
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }
        DatabaseProviderName? DatabaseProviderName { get; set; }
    }
}
