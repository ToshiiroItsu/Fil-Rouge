using FluentValidation;

namespace API_Fil_Rouge.Models.DTO.Entre
{
    /// <summary>
    /// DTO utilisé pour la création d'un Avis.
    /// </summary>

    public class CreateAvisDTO
    {
        /// <summary>
        /// Note d'un Avis.
        /// </summary>
        public int note { get; set; }
        public string? commentaire { get; set; }
        public int id_recette { get; set; }
        public int id_utilisateur { get; set; }

    }
    /// <summary>
    /// Validateur FluentValidation pour <see cref="CreateAvisDTO"/>.
    /// </summary>
    public class CreateAvisDTOValidator : AbstractValidator<CreateAvisDTO>
    {
        /// <summary>
        /// Initialise les règles de validation pour la création d'un Avis.
        /// </summary>
        public CreateAvisDTOValidator()
        {
            RuleFor(a => a.note).NotNull().NotEmpty().WithMessage("La note est obligatoire.");
            RuleFor(a => a.commentaire).NotNull().NotEmpty().WithMessage("Le commentaire est obligatoire.");
            RuleFor(a => a.id_recette).NotNull().NotEmpty().WithMessage("L'Id recette est obligatoire.");
            RuleFor(a => a.id_utilisateur).NotNull().NotEmpty().WithMessage("L'Id utilisateur est obligatoire.");
        }
    }
}
