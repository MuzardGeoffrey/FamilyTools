using EasyCompta.Server.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyCompta.Server.DataBase.Configuration
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

            // Relation avec AccountLines
            builder.HasMany(e => e.Lines)
                  .WithMany()
                  .UsingEntity(j => j.ToTable("AccountPageLines"));

            // Configuration du dictionnaire PaymentDone
            builder.HasMany<User>()
                  .WithMany()
                  .UsingEntity<Dictionary<string, object>>(
                      "AccountPagePayments",
                      j => j.HasOne<User>().WithMany().HasForeignKey("UserId"),
                      j => j.HasOne<AccountPage>().WithMany().HasForeignKey("AccountPageId"),
                      j =>
                      {
                          j.Property<bool>("IsPaid");
                          j.HasKey("UserId", "AccountPageId");
                      });
        }
    }
}
