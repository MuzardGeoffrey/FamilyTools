using FamilyTools.EasyCompta.Model;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyTools.EasyCompta.DataBase.Configuration
{
    public class AccountPageEntityTypeConfiguration : IEntityTypeConfiguration<AccountPage>
    {
        public void Configure(EntityTypeBuilder<AccountPage> builder)
        {
            builder.ToTable("AccountPages");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.IsClosing).IsRequired();
            builder.Property(e => e.Date).IsRequired();
            builder.Property(e => e.CreationDate).IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(e => e.UpdateDate);

            // Relation avec AccountEnters
            builder.HasMany(e => e.Enters)
                  .WithMany()
                  .UsingEntity(j => j.ToTable("AccountPageEnters"));

            // Configuration du dictionnaire PaymentDone
            builder.HasMany<User>()
                  .WithMany()
                  .UsingEntity<Dictionary<object, string>>(
                      "AccountPagePayments",
                      j => j.HasOne<User>().WithMany().HasForeignKey("UserId"),
                      j => j.HasOne<AccountPage>().WithMany().HasForeignKey("AccountPageId"),
                      j =>
                      {
                          j.HasKey("UserId", "AccountPageId");
                          j.Property<bool>("IsPaid");
                      });
        }
    }
}
