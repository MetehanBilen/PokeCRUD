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

public class PokemonRepository : EfRepositoryBase<Pokemon, Guid, BaseDbContext>, IPokemonRepository
{
    public PokemonRepository(BaseDbContext context) : base(context)
    {
    }
}
