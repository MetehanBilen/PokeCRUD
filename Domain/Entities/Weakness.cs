using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using z.Fellowship.Domain;

namespace Domain.Entities;

public class Weakness : BaseEntity<Guid>
{
    public string Name { get; set; }

    public virtual ICollection<Pokemon> Pokemons { get; set; }

    public Weakness()
    {
        Pokemons =new HashSet<Pokemon>();
    }
    public Weakness(Guid id, string name) : this()
    {
        Id = id;
        Name = name;
    }

}
