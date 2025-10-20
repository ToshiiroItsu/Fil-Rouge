using FluentValidation;

namespace API_Fil_Rouge.Models.DTO.Entre
{
    /// <summary>
    /// DTO utilisé pour la création d'une Catégorie.
    /// </summary>
    public class CreateCategorieDTO
    {
        /// <summary>
        /// Nom de la Catégorie.
        /// </summary>
        public string? nom { get; set; }
    }

    /// <summary>
    /// Validateur FluentValidation pour <see cref="CreateCategorieDTO"/>.
    /// </summary>
    public class CreateCategorieDTOValidator : AbstractValidator<CreateCategorieDTO>
    {
        /// <summary>
        /// Initialise les règles de validation pour la création d'une Catégorie.
        /// </summary>
        public CreateCategorieDTOValidator()
        {
            RuleFor(a => a.nom).NotNull().NotEmpty().WithMessage("Le nom est obligatoire.");
            
        }
    }
}
