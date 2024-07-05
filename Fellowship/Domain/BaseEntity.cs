using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace z.Fellowship.Domain;

public class BaseEntity<Tid> : IEntityTimestamps
{
    public Tid Id { get; set; }


    public DateTime CreatedDate { get ; set ; }
    public DateTime? UpdatedDate { get ; set ; }
    public DateTime? DeletedDate { get; set  ; }

    //boş çalışma constr.
    public BaseEntity()
    {
        Id = default;
    }
    //input varsa çalışma constr.
    public BaseEntity(Tid id)
    {
        Id = id;
    }
}
