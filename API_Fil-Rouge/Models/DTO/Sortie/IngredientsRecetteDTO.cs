namespace API_Fil_Rouge.Models.DTO.Sortie
{
    public class IngredientsRecetteDTO
    {
        public string fk_ingredient { get; set; }
        public string fk_recette { get; set; }
        public string quantite { get; set; }
    }
}
