namespace API_Fil_Rouge.Models.BO
{
    public class Recette
    {
        public int id { get; set; }
        public string? nom { get; set; }
        public TimeSpan temps_preparation { get; set; }
        public TimeSpan temps_cuisson { get; set; }
        public string? difficulte { get; set; }
        public string? cout { get; set; }
        public string? description { get; set; }
        public int nombrepersonne { get; set; }
        public string? image { get; set; }
        public IFormFile? imageFile { get; set; }
        public int id_utilisateur { get; set; }
    }
}
