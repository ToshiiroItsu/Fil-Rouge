namespace API_Fil_Rouge.Models.DTO.Sortie
{
    public class EtapeDTO
    {
        public int numero { get; set; }
        public string? nom_etape { get; set; }
        public string? texte { get; set; }
        public int id_recette { get; set; }
    }
}
