using FamilyTools.EasyCompta.Model;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyTools.EasyCompta.DataBase.Configuration
{
    public class AccountEnterEntityTypeConfiguration : IEntityTypeConfiguration<AccountEnter>
    {
        public void Configure(EntityTypeBuilder<AccountEnter> builder)
        {
            builder.ToTable("AccountEnters");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.TotalValue).IsRequired();
            builder.Property(e => e.LifeTime).IsRequired();
            builder.Property(e => e.CreationDate).IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(e => e.UpdateDate);

            // Relation avec AccountLines
            builder.HasMany(e => e.Lines)
                  .WithMany()
                  .UsingEntity(j => j.ToTable("AccountEnterLines"));

            // Relation avec AccountTag
            builder.HasOne(e => e.Tag)
                  .WithMany()
                  .HasForeignKey("TagId")
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
