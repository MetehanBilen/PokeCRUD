using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Abilities.Commands.Create;

public class CreatedAbilityResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Info { get; set; }
    public DateTime CreatedDate { get; set; }
}
