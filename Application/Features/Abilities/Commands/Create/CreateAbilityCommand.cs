using Application.Features.Abilities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Abilities.Commands.Create;

public class CreateAbilityCommand : IRequest <CreatedAbilityResponse>
{
    public string Name { get; set; }
    public string Info { get; set; }


    public class CreateAbilityCommandHandler : IRequestHandler<CreateAbilityCommand, CreatedAbilityResponse>
    {
        private readonly IAbilityRepository _abilityRepository;
        private readonly IMapper _mapper;

        //Business rules
        private readonly AbilityBusinessRules _abilityBusinessRules;


        public CreateAbilityCommandHandler(IAbilityRepository abilityRepository, IMapper mapper, AbilityBusinessRules abilityBusinessRules)
        {
            _abilityRepository = abilityRepository;
            _mapper = mapper;

            _abilityBusinessRules = abilityBusinessRules;
        }

        public async Task<CreatedAbilityResponse>? Handle(CreateAbilityCommand request, CancellationToken cancellationToken)
        {

             _abilityBusinessRules.AbilityNameCannotBeDuplicatedWhenInserted(request.Name);



            Ability ability = _mapper.Map<Ability>(request);
            ability.Id = Guid.NewGuid();

            await _abilityRepository.AddAsync(ability);

            CreatedAbilityResponse createdAbilityResponse = _mapper.Map<CreatedAbilityResponse>(ability);

            return createdAbilityResponse;
        }
    }
}
