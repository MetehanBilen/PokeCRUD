using Moq;
using Xunit;
using AutoMapper;
using System.Threading.Tasks;
using System.Threading;
using FluentAssertions;
using Application.Services.Repositories;
using Application.Features.Abilities.Rules;
using static Application.Features.Abilities.Commands.Create.CreateAbilityCommand;
using Application.Features.Abilities.Commands.Create;
using Domain.Entities;
using z.Fellowship.Application.Rules;
using System.Linq.Expressions;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace PokeCRUD.Tests;

public class CreateAbilityCommandHandlerTests
{
    private readonly Mock<IAbilityRepository> _mockAbilityRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly AbilityBusinessRules _abilityBusinessRules;
    private readonly CreateAbilityCommandHandler _handler;



    public CreateAbilityCommandHandlerTests()
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
            Name = "Fireball",
            Info = "A powerful fire spell."
        };
        var ability = new Ability
        {
            Name = command.Name,
            Info = command.Info,
        };

        var createdAbilityResponse = new CreatedAbilityResponse
        {
            Name = command.Name,
            Info = command.Info,
        };

        _mockAbilityRepository.Setup(repo => repo.Get(It.IsAny<Expression<Func<Ability, bool>>>()))
                       .Returns<Expression<Func<Ability, bool>>>(filter => {
                           // Simulate repository behavior
                           var abilities = new List<Ability>
                           {
                              new Ability { Id = new Guid(), Name = "Water Something" },
                              new Ability { Id = new Guid(), Name = "Healing Touch" }
                              // Add more abilities as needed
                           };
                           return abilities.SingleOrDefault(filter.Compile());
                       });

        _mockMapper.Setup(x => x.Map<Ability>(command)).Returns(ability);


        _mockAbilityRepository.Setup(x => x.AddAsync(ability)).Returns(Task.FromResult(ability));
        _mockMapper.Setup(x => x.Map<CreatedAbilityResponse>(ability)).Returns(createdAbilityResponse);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(ability.Name, result.Name);
        Assert.IsType<CreatedAbilityResponse> (result);
    }

}