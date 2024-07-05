using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using z.Fellowship.Persistence.Repositories;

namespace Persistence.Repositories;

public class WeaknessRepository : EfRepositoryBase<Weakness, Guid, BaseDbContext>, IWeaknessRepository
{
    public WeaknessRepository(BaseDbContext context) : base(context)
    {
    }
}
