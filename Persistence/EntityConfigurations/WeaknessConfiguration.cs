using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations;

public class WeaknessConfiguration : IEntityTypeConfiguration<Weakness>
{
    public void Configure(EntityTypeBuilder<Weakness> builder)
    {
        builder.ToTable("Weaknesses").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.Name).HasColumnName("Name").IsRequired();


        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: a => a.Name, name: "UK_Weaknesses_Name").IsUnique();
        builder.HasMany(a => a.Pokemons);

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}
