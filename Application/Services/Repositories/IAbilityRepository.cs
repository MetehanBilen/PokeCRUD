using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using z.Fellowship.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAbilityRepository : IAsyncRepository<Ability,Guid>
{
    Ability Get(Expression<Func<Ability, bool>> filter);
}
