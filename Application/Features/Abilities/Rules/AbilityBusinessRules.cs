using Application.Features.Abilities.Constans;
using Application.Services.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using z.Fellowship.Application.Rules;
using z.Fellowship.CrossCuttingConcerns.Exceptions.Types;

namespace Application.Features.Abilities.Rules;

public class AbilityBusinessRules : BaseBusinessRules
{
    private readonly IAbilityRepository _abilityRepository;

    public AbilityBusinessRules(IAbilityRepository abilityRepository)
    {
        _abilityRepository = abilityRepository;
    }

    //Rule One
    public void AbilityNameCannotBeDuplicatedWhenInserted(string name)
    {
        Ability? result =  _abilityRepository.Get( a => a.Name.ToLower() == name.ToLower());
        if (result != null)
        {
            throw new BusinessException(AbilitiesMessages.AbilityNameExists);
        }
       
    }

    public async Task AbilityNameCannotBeDuplicatedWhenInsertedAsync(string name)
    {
        Ability? result = await _abilityRepository.GetAsync(a => a.Name.ToLower() == name.ToLower());
        if (result != null)
        {
            throw new BusinessException(AbilitiesMessages.AbilityNameExists);
        }

    }
}
