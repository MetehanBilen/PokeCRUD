using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using z.Fellowship.Domain;

namespace Domain.Entities;

public class Pokemon : BaseEntity<Guid>
{
    public string Name { get; set; }
    public Guid AbilityId { get; set; }


    public virtual Ability? Ability { get; set; }
    public virtual ICollection<Weakness> Weaknesses { get; set; }

    public Pokemon()
    {
        Weaknesses = new HashSet<Weakness>();
    }

    public Pokemon(Guid id,string name,Guid abilityId)
    {
        Id = id;
        Name = name;
        AbilityId = abilityId;
        
    }

}
