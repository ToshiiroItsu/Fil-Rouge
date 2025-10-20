namespace API_Fil_Rouge.Models.BO
{
    public class Utilisateur
    {
        public int id { get; set; }
        public string? identifiant { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? role { get; set; }
    }
}
