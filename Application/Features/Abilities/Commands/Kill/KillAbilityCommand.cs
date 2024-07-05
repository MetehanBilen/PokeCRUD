using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Abilities.Commands.Kill;

public class KillAbilityCommand :IRequest<KilledAbilityResponse>
{
    public Guid Id { get; set; }

    public class KillAbilityCommmandHandler : IRequestHandler<KillAbilityCommand, KilledAbilityResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAbilityRepository _abilityRepository;

        public KillAbilityCommmandHandler(IAbilityRepository abilityRepository, IMapper mapper)
        {
            _abilityRepository = abilityRepository;
            _mapper = mapper;
        }

        public async Task<KilledAbilityResponse> Handle(KillAbilityCommand request, CancellationToken cancellationToken)
        {
            Ability? ability = await _abilityRepository.GetAsync(predicate: a => a.Id == request.Id,cancellationToken: cancellationToken);

            await _abilityRepository.KillAsync(ability);

            KilledAbilityResponse response = _mapper.Map<KilledAbilityResponse>(ability);

            return response;
        }
    }
}
