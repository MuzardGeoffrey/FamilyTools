using FamilyTools.EasyCompta.Model;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyTools.EasyCompta.DataBase.Configuration
{
    public class TemplateEntityTypeConfiguration : IEntityTypeConfiguration<Template>
    {
        public void Configure(EntityTypeBuilder<Template> builder)
        {
            builder.ToTable("Templates");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.LifeTime).IsRequired();
            builder.Property(e => e.CreationDate).IsRequired().HasDefaultValueSql("getdate()"); ;
            builder.Property(e => e.UpdateDate);

            // Relation avec AccountLines
            builder.HasMany(e => e.Lines)
                  .WithMany()
                  .UsingEntity(j => j.ToTable("TemplateLines"));
        }
    }
}
