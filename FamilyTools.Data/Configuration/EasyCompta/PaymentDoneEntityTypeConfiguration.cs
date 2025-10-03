﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FamilyTools.Data.Models.EasyCompta;

namespace FamilyTools.Data.Configuration.EasyCompta
{
    public class PaymentDoneEntityTypeConfiguration : IEntityTypeConfiguration<PaymentDone>
    {
        public void Configure(EntityTypeBuilder<PaymentDone> builder)
        {
            builder.ToTable("AccountEnters");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.User).IsRequired();
            builder.Property(e => e.Total).IsRequired();
            builder.Property(e => e.PaymentIsDone).IsRequired();
            builder.Property(e => e.CreationDate).IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(e => e.UpdateDate);

            // Relation avec User
            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
