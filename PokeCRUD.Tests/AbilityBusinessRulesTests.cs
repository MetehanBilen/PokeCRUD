using Application.Features.Abilities.Constans;
using Application.Features.Abilities.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using z.Fellowship.CrossCuttingConcerns.Exceptions.Types;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PokeCRUD.Tests;

public class AbilityBusinessRulesTests
{
    private readonly Mock<IAbilityRepository> _mockAbilityRepository;
    public AbilityBusinessRulesTests()
    {
        _mockAbilityRepository = new Mock<IAbilityRepository>();
    }
    [Fact]
    public void Ability_BusinessRules_WhenAbilityNameExists_ThrowExeption()
    {

        var expectedAbility = new Ability { Id = new Guid(), Name = "Fireball" };


        _mockAbilityRepository.Setup(repo => repo.Get(It.IsAny<Expression<Func<Ability, bool>>>()))
                      .Returns<Expression<Func<Ability, bool>>>(filter => {
                          // Simulate repository behavior
                          var abilities = new List<Ability>
                          {
                              new Ability { Id = new Guid(), Name = "Fireball" },
                              new Ability { Id = new Guid(), Name = "Healing Touch" }
                              // Add more abilities as needed
                          };
                          return abilities.SingleOrDefault(filter.Compile());
                      });


        var businessRules = new AbilityBusinessRules(_mockAbilityRepository.Object);

        // Act & Assert
        var ex = Assert.Throws<BusinessException>(() => businessRules.AbilityNameCannotBeDuplicatedWhenInserted(expectedAbility.Name));
        Assert.Equal(AbilitiesMessages.AbilityNameExists, ex.Message);


    }

    [Fact]
    public void Ability_BusinessRules_AbilityNameIsNotExists()
    {

        var expectedAbility = new Ability { Id = new Guid(), Name = "Water something" };


        _mockAbilityRepository.Setup(repo => repo.Get(It.IsAny<Expression<Func<Ability, bool>>>()))
                      .Returns<Expression<Func<Ability, bool>>>(filter => {
                          // Simulate repository behavior
                          var abilities = new List<Ability>
                          {
                              new Ability { Id = new Guid(), Name = "Fireball" },
                              new Ability { Id = new Guid(), Name = "Healing Touch" }
                              // Add more abilities as needed
                          };
                          return abilities.SingleOrDefault(filter.Compile());
                      });


        var businessRules = new AbilityBusinessRules(_mockAbilityRepository.Object);


        var ex = Record.Exception(() => businessRules.AbilityNameCannotBeDuplicatedWhenInserted(expectedAbility.Name));
        Assert.Null(ex);


    }
}