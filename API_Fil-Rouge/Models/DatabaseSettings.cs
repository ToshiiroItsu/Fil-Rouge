using FluentValidation;

namespace API_Fil_Rouge.Models
{
    public enum DatabaseProviderName
    {
        PostgreSQL
    }
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public DatabaseProviderName? DatabaseProviderName { get; set; }

    }

    public class DatabaseSettingsValidator : AbstractValidator<DatabaseSettings>
    {
        public DatabaseSettingsValidator()
        {
            var connectionMessage = "La chaîne de connexion est invalide.";
            var providerMessage = $"Le type de base de données est invalide. Valeurs possibles : {string.Join(", ", Enum.GetNames(typeof(DatabaseProviderName)))}";

            RuleFor(x => x.ConnectionString)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage(connectionMessage)
                .NotEmpty().WithMessage(connectionMessage);

            RuleFor(x => x.DatabaseProviderName)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage(providerMessage)
                .IsInEnum().WithMessage(providerMessage);
        }
    }
}
