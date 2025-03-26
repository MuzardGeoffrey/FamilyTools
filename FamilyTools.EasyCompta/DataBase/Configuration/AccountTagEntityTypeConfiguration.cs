using EasyCompta.Server.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyCompta.Server.DataBase.Configuration
{
    public class AccountTagEntityTypeConfiguration : IEntityTypeConfiguration<AccountTag>
    {
        public void Configure(EntityTypeBuilder<AccountTag> builder)
        {
            builder.ToTable("AccountTags");
            builder.HasKey(e => e.Id);
            builder.HasAlternateKey(e => e.Name);
            builder.Property(e => e.Color);
            builder.Property(e => e.CreationDate).IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(e => e.UpdateDate);
        }
    }
}
