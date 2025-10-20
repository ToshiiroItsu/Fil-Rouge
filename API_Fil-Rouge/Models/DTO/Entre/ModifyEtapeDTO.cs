using FluentValidation;

namespace API_Fil_Rouge.Models.DTO.Entre
{
    /// <summary>
    /// DTO utilisé pour la mise à jour d'une Etape.
    /// </summary>
    public class ModifyEtapeDTO
    {
        /// <summary>
        /// Numero de l'Etape.
        /// </summary>
        public int numero { get; set; }
        public string? nom_etape { get; set; }
        public string? texte { get; set; }
        public int id_recette { get; set; }
    }
    /// <summary>
    /// Validateur FluentValidation pour <see cref="ModifyEtapeDTO"/>.
    /// </summary>
    public class ModifyEtapeDTOValidator : AbstractValidator<ModifyEtapeDTO>
    {
        /// <summary>
        /// Initialise les règles de validation pour la mise à jour d'une Etape.
        /// </summary>
        public ModifyEtapeDTOValidator()
        {
            RuleFor(a => a.numero).NotNull().NotEmpty().WithMessage("Le numéro est obligatoire.");
            RuleFor(a => a.nom_etape).NotNull().NotEmpty().WithMessage("Le nom de l'étape est obligatoire.");
            RuleFor(a => a.texte).NotNull().NotEmpty().WithMessage("Le texte est obligatoire.");
            RuleFor(a => a.id_recette).NotNull().NotEmpty().WithMessage("L'Id de la recette est obligatoire.");
        }
    }
}
