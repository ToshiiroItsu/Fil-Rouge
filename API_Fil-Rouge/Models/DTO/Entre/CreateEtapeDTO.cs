using FluentValidation;

namespace API_Fil_Rouge.Models.DTO.Entre
{
    /// <summary>
    /// DTO utilisé pour la création d'une Etape.
    /// </summary>
    public class CreateEtapeDTO
    {
        /// <summary>
        /// Numéro d'une Etape.
        /// </summary>
        public int numero { get; set; }
        public string? nom_etape { get; set; }
        public string? texte { get; set; }
        public int id_recette { get; set; }
    }
    /// <summary>
    /// Validateur FluentValidation pour <see cref="CreateEtapeDTO"/>.
    /// </summary>
    public class CreateEtapeDTOValidator : AbstractValidator<CreateEtapeDTO>
    {
        /// <summary>
        /// Initialise les règles de validation pour la création d'une Etape.
        /// </summary>
        public CreateEtapeDTOValidator()
        {
            RuleFor(a => a.numero).NotNull().NotEmpty().WithMessage("Le numéro est obligatoire.");
            RuleFor(a => a.nom_etape).NotNull().NotEmpty().WithMessage("Le nom de l'étape est obligatoire.");
            RuleFor(a => a.texte).NotNull().NotEmpty().WithMessage("Le texte est obligatoire.");
            RuleFor(a => a.id_recette).NotNull().NotEmpty().WithMessage("L'Id de la recette est obligatoire.");
        }
    }
}
