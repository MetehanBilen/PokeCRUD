using Application.Features.Abilities.Commands.Kill;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Abilities.Queries.GetById;

public class GetByIdAbilityQuery : IRequest<GetByIdAbilityResponse>
{
    public Guid Id { get; set; }
    public class GetByIdAbilityQueryHandler : IRequestHandler<GetByIdAbilityQuery, GetByIdAbilityResponse>
    {

        private readonly IMapper _mapper;
        private readonly IAbilityRepository _abilityRepository;

        public GetByIdAbilityQueryHandler(IAbilityRepository abilityRepository, IMapper mapper)
        {
            _abilityRepository = abilityRepository;
            _mapper = mapper;
        }
        public async Task<GetByIdAbilityResponse> Handle(GetByIdAbilityQuery request, CancellationToken cancellationToken)
        {
            Ability? ability = await _abilityRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);

            GetByIdAbilityResponse response = _mapper.Map<GetByIdAbilityResponse>(ability);

            return response;
        }
    }
}
