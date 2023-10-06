using FluentValidation;
using MinimalApiRealState.Feats.Properties.Dtos;

namespace MinimalApiRealState.Feats.Properties.Validations;

public class PropertyValidatorCreate : AbstractValidator<CreatePropertyDto>
{
    public PropertyValidatorCreate()
    {
        RuleFor(model => model.Name).NotEmpty();
        RuleFor(model => model.Description).NotEmpty();
        RuleFor(model => model.Location).NotEmpty();
    }
}

public class PropertyValidatorUpdate : AbstractValidator<UpdatePropertyDto>
{
    public PropertyValidatorUpdate()
    {
        RuleFor(model => model.Name).NotEmpty();
        RuleFor(model => model.Description).NotEmpty();
        RuleFor(model => model.Location).NotEmpty();
    }
}
