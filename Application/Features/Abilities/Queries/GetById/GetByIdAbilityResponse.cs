using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Abilities.Queries.GetById;

public class GetByIdAbilityResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Info { get; set; }
}
