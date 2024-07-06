using Application.Features.Abilities.Commands.Create;
using Application.Features.Abilities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Application.Features.Abilities.Commands.Create.CreateAbilityCommand;

namespace PokeCRUD.Tests;

public class GetAsyncUnitTest
{
    private readonly Mock<IAbilityRepository> _mockAbilityRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly AbilityBusinessRules _abilityBusinessRules;
    private readonly CreateAbilityCommandHandler _handler;

    public GetAsyncUnitTest()
    {
        _mockAbilityRepository = new Mock<IAbilityRepository>();
        _mockMapper = new Mock<IMapper>();

        _abilityBusinessRules = new AbilityBusinessRules(_mockAbilityRepository.Object);

        _handler = new CreateAbilityCommandHandler(
            _mockAbilityRepository.Object,
            _mockMapper.Object,
            _abilityBusinessRules
        );
    }

    [Fact]
    public async Task Handle_ValidCommand_ShouldCreateAbilityAndReturnResponse()
    {
        // Arrange
        var command = new CreateAbilityCommand
        {
            Name = "Regular Punch",
            Info = "A powerful punch."
        };

        var ability = new Ability
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Info = command.Info
        };

        var createdAbilityResponse = new CreatedAbilityResponse
        {
            Id = ability.Id,
            Name = ability.Name,
            Info = ability.Info
        };

        Expression<Func<Ability, bool>> predicate = e => e.Name.ToLower() == ability.Name.ToLower();
        _mockAbilityRepository.Setup(repo => repo.GetAsync(predicate, null, false, true, CancellationToken.None))
            .ReturnsAsync((Ability?)null);

        _mockMapper.Setup(x => x.Map<Ability>(command)).Returns(ability);
        _mockAbilityRepository.Setup(x => x.AddAsync(ability)).ReturnsAsync(ability);
        _mockMapper.Setup(x => x.Map<CreatedAbilityResponse>(ability)).Returns(createdAbilityResponse);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(ability.Name, result.Name);
        Assert.IsType<CreatedAbilityResponse>(result);
    }

}
