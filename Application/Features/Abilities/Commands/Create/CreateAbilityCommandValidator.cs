using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Abilities.Commands.Create;

public class CreateAbilityCommandValidator : AbstractValidator<CreateAbilityCommand>
{
    public CreateAbilityCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(2);
    }
}
