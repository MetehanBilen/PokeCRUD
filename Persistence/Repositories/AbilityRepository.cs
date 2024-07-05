using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using z.Fellowship.Persistence.Repositories;
using Application.Services.Repositories;


namespace Persistence.Repositories;

public class AbilityRepository : EfRepositoryBase<Ability, Guid, BaseDbContext>, IAbilityRepository
{
    public AbilityRepository(BaseDbContext context) : base(context)
    {
    }
}
