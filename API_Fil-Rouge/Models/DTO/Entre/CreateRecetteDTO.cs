using FluentValidation;

namespace API_Fil_Rouge.Models.DTO.Entre
{
    /// <summary>
    /// DTO utilisé pour la création d'une Recette.
    /// </summary>
    public class CreateRecetteDTO
    {
        /// <summary>
        /// Le nom de la Recette
        /// </summary>
        public string? nom { get; set; }
        public TimeSpan temps_preparation { get; set; }
        public TimeSpan temps_cuisson { get; set; }
        public string? difficulte { get; set; }
        public string? cout { get; set; }
        public string? description { get; set; }
        public int nombrepersonne { get; set; }
        public string? image { get; set; }
        public int fk_utilisateur { get; set; }
    }

    /// <summary>
    /// Validateur FluentValidation pour <see cref="CreateRecetteDTO"/>.
    /// </summary>
    public class CreateRecetteDTOValidator : AbstractValidator<CreateRecetteDTO>
    {
        /// <summary>
        /// Initialise les règles de validation pour la création d'une Recette.
        /// </summary>
        public CreateRecetteDTOValidator()
        {
            RuleFor(a => a.nom).NotNull().NotEmpty().WithMessage("Le nom est obligatoire.");
            RuleFor(a => a.temps_preparation).NotNull().NotEmpty().WithMessage("Le temps de préparation est obligatoire.");
            RuleFor(a => a.temps_cuisson).NotNull().NotEmpty().WithMessage("Le temps de cuisson est obligatoire.");
            RuleFor(a => a.difficulte).NotNull().NotEmpty().WithMessage("La difficulter de la recette est obligatoire.");
            RuleFor(a => a.cout).NotNull().NotEmpty().WithMessage("Le cout de la recette est obligatoire.");
            RuleFor(a => a.description).NotNull().NotEmpty().WithMessage("La description de la recette est obligatoire.");
            RuleFor(a => a.nombrepersonne).NotNull().NotEmpty().WithMessage("Le nombre de personne est obligatoire.");          
            RuleFor(a => a.fk_utilisateur).NotNull().NotEmpty().WithMessage("L'Id de l'utilisateur est obligatoire.");
        }
    }
}
