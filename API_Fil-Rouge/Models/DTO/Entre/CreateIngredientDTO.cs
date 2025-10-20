using FluentValidation;

namespace API_Fil_Rouge.Models.DTO.Entre
{
    /// <summary>
    /// DTO utilisé pour la création d'un Ingredient.
    /// </summary>
    public class CreateIngredientDTO
    {
        /// <summary>
        /// Nom de l'Ingrédient.
        /// </summary>
        public string? nom { get; set; }
        public string? quantite { get; set; }
    }

    /// <summary>
    /// Validateur FluentValidation pour <see cref="CreateIngredientDTO"/>.
    /// </summary>
    public class CreateIngredientDTOValidator : AbstractValidator<CreateIngredientDTO>
    {
        /// <summary>
        /// Initialise les règles de validation pour la création d'un Ingredient.
        /// </summary>
        public CreateIngredientDTOValidator()
        {
            RuleFor(a => a.nom).NotNull().NotEmpty().WithMessage("Le nom est obligatoire.");
            RuleFor(a => a.quantite).NotNull().NotEmpty().WithMessage("La quantité est obligatoire.");
        }
    }
}
