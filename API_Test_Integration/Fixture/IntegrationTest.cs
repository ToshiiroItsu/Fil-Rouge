using API_Fil_Rouge.Models.BO;
using API_Fil_Rouge.Models.DTO.Sortie;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;
using System.Net.Http.Json;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace API_Fil_Rouge.APITestIntegration.Fixture;

public class IntegrationTest : IClassFixture <APIWebApplicationFactory>
{
    public HttpClient httpClient { get; set; }
    private IConfiguration _configuration { get; set; }
    public IntegrationTest(APIWebApplicationFactory webApi)
    {
        //instancier le client
        httpClient = webApi.CreateClient();
        _configuration = webApi.Configuration;


    }

    public async Task Login(string username, string password)
    {
        var httpResponse = await httpClient.PostAsJsonAsync<LoginDTO>("/api/access/Login", new()
        {
            Username = username,
            Password = password
        });

        if (httpResponse.IsSuccessStatusCode)
        {

            var JwtDTO = await httpResponse.Content.ReadFromJsonAsync<JwtDTO>();
            httpClient.DefaultRequestHeaders.Authorization = new("bearer", JwtDTO.Token);
        }
        else
        {
            Assert.Fail($"Impossible de se conecter avec {username}, {password}");
        }
    }

    public void Logout()
    {
        httpClient.DefaultRequestHeaders.Authorization = null;
    }


    public void UpDatabase()
    {
        DownDatabase();
        var stringConnection = _configuration.GetSection("DataBaseSettings").GetValue<string>("ConnectionString");
        IDbConnection con = new NpgsqlConnection(stringConnection);

        con.Open();
        string requeteSQL = File.ReadAllText("CreateDatabase.sql");
        var commande = con.CreateCommand();
        commande.CommandText = requeteSQL;
        commande.ExecuteNonQuery();
        con.Dispose();
    }

    public void DownDatabase()
    {
        var stringConnection = _configuration.GetSection("DataBaseSettings").GetValue<string>("ConnectionString");
        using (IDbConnection con = new NpgsqlConnection(stringConnection))
        {
            con.Open();
            string requeteSQL = "DROP SCHEMA if exists public CASCADE;";
            var commande = con.CreateCommand();
            commande.CommandText = requeteSQL;
            commande.ExecuteNonQuery();
        }
    }
}
