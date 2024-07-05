using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations;

public class PokemonsConfiguration : IEntityTypeConfiguration<Pokemon>
{
    public void Configure(EntityTypeBuilder<Pokemon> builder)
    {
        builder.ToTable("Pokemons").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.Name).HasColumnName("Name").IsRequired();

        builder.Property(a => a.AbilityId).HasColumnName("AbilityId").IsRequired();


        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: a => a.Name, name: "UK_Pokemon_Name").IsUnique();

        builder.HasOne(a => a.Ability).WithMany(ap => ap.Pokemons).HasForeignKey(a => a.AbilityId);
        builder.HasMany(a => a.Weaknesses);

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}
