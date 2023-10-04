using FluentValidation;
using MinimalApiRealState.Feats.Properties.Dtos;

namespace MinimalApiRealState.Feats.Properties.Validations;

public class PropertyValidator : AbstractValidator<CreatePropertyDto>
{
    public PropertyValidator()
    {
        RuleFor(model => model.Name).NotEmpty();
        RuleFor(model => model.Description).NotEmpty();
        RuleFor(model => model.Location).NotEmpty();
    }
}
