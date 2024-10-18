using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PP.Module.QuoteManager.Contract.Entities;
using System;
using System.Collections.Generic;

namespace PP.Module.QuoteManager.Dal.Configurations
{
    public class QuoteEntityTypeConfiguration : IEntityTypeConfiguration<Quote>
    {
        public void Configure(EntityTypeBuilder<Quote> builder)
        {
            builder
                .HasKey(x => x.QuoteRef);

            builder
                .Property(x => x.QuoteRef)
                .HasColumnName("QuoteRef")
                .IsUnicode(true);

            builder
                .Property(x => x.DateCreated)
                .HasColumnName("DateCreated")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder
                .ToTable("Quote", "dbo");
        }
    }
}
