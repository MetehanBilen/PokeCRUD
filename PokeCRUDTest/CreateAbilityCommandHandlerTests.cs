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

namespace PokeCRUDTest;

public class CreateAbilityCommandHandlerTests
{
    private readonly Mock<IAbilityRepository> _mockAbilityRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly AbilityBusinessRules _abilityBusinessRules;
    private readonly CreateAbilityCommandHandler _handler;


    private readonly Mock<DbContext> _dbContext;

    public CreateAbilityCommandHandlerTests()
    {
        _mockAbilityRepository = new Mock<IAbilityRepository>();
        _mockMapper = new Mock<IMapper>();

        _abilityBusinessRules = new AbilityBusinessRules(_mockAbilityRepository.Object);
        
        _dbContext = new Mock<DbContext>();

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

        List<Ability>  abilities = new List<Ability> { ability };


        
        //Mock<Ability> dbContext = new Mock<Ability>();

        ////Problem here
        //var abilities = new[] {ability}.AsQueryable();

        //IQueryable<Ability> Query() => dbContext.Set<Ability>()


        //Expression<Func<Ability, bool>> predicate = e => e.Name == ability.Name;
        //Func<IQueryable<Ability>> queryable = () => abilities.Where(a=> a.Name == "Fire");

        _mockAbilityRepository.Setup(x => x.GetAsync(predicate,null,queryable)).Returns( new[] { ability }.AsQueryable());

        _mockMapper.Setup(x => x.Map<Ability>(command)).Returns(ability);
        _mockAbilityRepository.Setup(x => x.AddAsync(ability)).Returns(Task.FromResult(ability));
        _mockMapper.Setup(x => x.Map<CreatedAbilityResponse>(ability)).Returns(createdAbilityResponse);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(ability.Id);
        result.Name.Should().Be(ability.Name);
        result.Info.Should().Be(ability.Info);

        _mockMapper.Verify(x => x.Map<Ability>(command), Times.Once);
        _mockAbilityRepository.Verify(x => x.AddAsync(ability), Times.Once);
        _mockMapper.Verify(x => x.Map<CreatedAbilityResponse>(ability), Times.Once);
    }
}