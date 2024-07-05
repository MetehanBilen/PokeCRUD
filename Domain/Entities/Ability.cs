using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using z.Fellowship.Domain;

namespace Domain.Entities;

public class Ability : BaseEntity<Guid>
{
    public string Name { get; set; }
    public string Info { get; set; }

    public virtual ICollection<Pokemon> Pokemons { get; set; }

    public Ability()
    {
        Pokemons = new HashSet<Pokemon>();
    }
    public Ability(Guid id, string name) : this()
    {
        Id = id;
        Name = name;
    }

}
