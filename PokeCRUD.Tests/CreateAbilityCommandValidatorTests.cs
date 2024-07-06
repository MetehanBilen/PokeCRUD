using Application.Features.Abilities.Commands.Create;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCRUD.Tests;

public class CreateAbilityCommandValidatorTests
{
    private readonly CreateAbilityCommandValidator _validator;

    public CreateAbilityCommandValidatorTests()
    {
        _validator = new CreateAbilityCommandValidator();
    }

    [Fact]
    public void Name_Should_Not_Be_Empty()
    {
        // Arrange
        var command = new CreateAbilityCommand { Name = "" };

        // Act
        var result = _validator.TestValidate(command); //TestValidate için FluentValidation.TestHelper kur


        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name)
              .WithErrorMessage("'Name' must not be empty.");
    }

    [Fact]
    public void Name_Should_Have_Minimum_Length_Of_2_Characters()
    {
        // Arrange
        var command = new CreateAbilityCommand { Name = "A" };

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name)
              .WithErrorMessage("The length of 'Name' must be at least 2 characters. You entered 1 characters.");
    }

    [Fact]
    public void Name_With_Valid_Length_Should_Pass()
    {
        // Arrange
        var command = new CreateAbilityCommand { Name = "Fireball" };

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
