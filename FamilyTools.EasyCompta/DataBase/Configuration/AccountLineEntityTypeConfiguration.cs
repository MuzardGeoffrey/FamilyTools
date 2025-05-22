﻿using FamilyTools.EasyCompta.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyTools.EasyCompta.DataBase.Configuration
{
    public class AccountLineEntityTypeConfiguration : IEntityTypeConfiguration<AccountLine>
    {
        public void Configure(EntityTypeBuilder<AccountLine> builder)
        {
            builder.ToTable("AccountLines");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Value).IsRequired();
            builder.Property(e => e.CreationDate).IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(e => e.UpdateDate);

            // Relation avec User
            builder.HasOne(e => e.User)
                  .WithMany()
                  .HasForeignKey(e => e.UserId)
                  .IsRequired();
        }
    }
}
