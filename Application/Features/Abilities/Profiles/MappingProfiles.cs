using Application.Features.Abilities.Commands.Create;
using Application.Features.Abilities.Commands.Kill;
using Application.Features.Abilities.Queries.GetById;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Abilities.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Ability,CreateAbilityCommand>().ReverseMap();
        CreateMap<Ability, CreatedAbilityResponse>().ReverseMap();


        CreateMap<Ability, KillAbilityCommand>().ReverseMap();
        CreateMap<Ability, KilledAbilityResponse>().ReverseMap();


        CreateMap<Ability, GetByIdAbilityQuery>().ReverseMap();
        CreateMap<Ability, GetByIdAbilityResponse>().ReverseMap();
    }
}
