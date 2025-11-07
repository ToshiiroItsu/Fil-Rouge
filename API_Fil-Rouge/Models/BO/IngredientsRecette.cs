namespace API_Fil_Rouge.Models.BO
{
    public class IngredientsRecette
    {
        public string fk_ingredient { get; set; }
        public string fk_recette { get; set; }
        public string quantite { get; set; }
    }
}
