using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PP.Module.QuoteManager.Contract.Entities;
using System;
using System.Collections.Generic;

namespace PP.Module.QuoteManager.Dal.Configurations
{
    public class SeedSegmentEntityTypeConfiguration : IEntityTypeConfiguration<SeedSegment>
    {
        public void Configure(EntityTypeBuilder<SeedSegment> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(x => x.SeedSegmentSeed)
                .WithMany(x => x.SeedSegmentSeeds)
                .HasForeignKey(x => x.SeedKey)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.Id)
                .HasColumnName("Id")
                .HasPrecision(10, 0);

            builder
                .Property(x => x.SeekCode)
                .HasColumnName("SeekCode")
                .IsUnicode(true);

            builder
                .Property(x => x.Threshold)
                .HasColumnName("Threshold")
                .HasPrecision(10, 0);

            builder
                .Property(x => x.SeedValue)
                .HasColumnName("SeedValue")
                .HasPrecision(10, 0);

            builder
                .ToTable("SeedSegment", "dbo");
        }
    }
}
