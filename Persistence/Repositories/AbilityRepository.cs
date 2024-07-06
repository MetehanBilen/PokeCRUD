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
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Persistence.Repositories;

public class AbilityRepository : EfRepositoryBase<Ability, Guid, BaseDbContext>, IAbilityRepository
{
    public AbilityRepository(BaseDbContext context) : base(context)
    {
    }

    public Ability Get(Expression<Func<Ability, bool>> filter)
    {

        return Context.Set<Ability>().SingleOrDefault(filter);

    }

}
