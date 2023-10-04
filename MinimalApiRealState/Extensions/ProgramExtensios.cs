using FluentValidation;

namespace MinimalApiRealState.Extensions;

public static class ProgramExtensios
{
    public static void AddAppExtesions(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<Program>();
    }
}
