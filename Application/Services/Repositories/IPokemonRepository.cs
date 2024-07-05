using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using z.Fellowship.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IPokemonRepository : IAsyncRepository<Pokemon,Guid>
{
}
