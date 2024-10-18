using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PP.Module.QuoteManager.Contract.Entities;
using System;
using System.Collections.Generic;

namespace PP.Module.QuoteManager.Dal.Configurations
{
    public class SeedEntityTypeConfiguration : IEntityTypeConfiguration<Seed>
    {
        public void Configure(EntityTypeBuilder<Seed> builder)
        {
            builder
                .HasKey(x => x.SeedKey);

            builder
                .Property(x => x.SeedKey)
                .HasColumnName("SeedKey")
                .IsUnicode(true);

            builder
                .Property(x => x.Format)
                .HasColumnName("Format")
                .IsUnicode(true);

            builder
                .ToTable("Seed", "dbo");
        }
    }
}
