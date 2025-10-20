using FluentValidation;

namespace API_Fil_Rouge.Models.DTO.Entre
{
    /// <summary>
    /// DTO utilisé pour la mise à jour d'une Catégorie.
    /// </summary>
    public class ModifyCategorieDTO
    {


        /// <summary>
        /// Nom de la Catégorie.
        /// </summary>

        public string? nom { get; set; }

    }
    /// <summary>
    /// Validateur FluentValidation pour <see cref="ModifyCategorieDTO"/>.
    /// </summary>
    public class ModifyCategorieDTOValidator : AbstractValidator<ModifyCategorieDTO>
    {
        /// <summary>
        /// Initialise les règles de validation pour la mise à jour d'une Categorie.
        /// </summary>
        public ModifyCategorieDTOValidator()
        {
            RuleFor(a => a.nom).NotNull().NotEmpty().WithMessage("Le nom est obligatoire.");

        }
    }
}
