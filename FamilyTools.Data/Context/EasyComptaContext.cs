
using FamilyTools.Data.Configuration.EasyCompta;
using FamilyTools.Data.Models.EasyCompta;
using FamilyTools.Data.Seed.EasyCompta;

using Microsoft.EntityFrameworkCore;

namespace FamilyTools.Data.Context
{
    public class EasyComptaContext : DbContext
    {
        public EasyComptaContext(DbContextOptions<EasyComptaContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<AccountEnter> AccountEnters { get; set; }
        public DbSet<AccountLine> AccountLines { get; set; }
        public DbSet<AccountPage> AccountPages { get; set; }
        public DbSet<AccountTag> AccountTags { get; set; }
        public DbSet<Template> Templates { get; set; }

        public async Task EnsureSeedData()
        {
            ContextInitializer initializer = new();
            await initializer.Seed(this);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration de User
            new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());

            // Configuration de AccountTag
            new AccountTagEntityTypeConfiguration().Configure(modelBuilder.Entity<AccountTag>());

            // Configuration de AccountLine
            new AccountLineEntityTypeConfiguration().Configure(modelBuilder.Entity<AccountLine>());
            
            // Configuration de AccountEnter
            new AccountEnterEntityTypeConfiguration().Configure(modelBuilder.Entity<AccountEnter>());

            // Configuration de AccountPage
            new AccountPageEntityTypeConfiguration().Configure(modelBuilder.Entity<AccountPage>());
            
            // Configuration de Template
            new TemplateEntityTypeConfiguration().Configure(modelBuilder.Entity<Template>());

            base.OnModelCreating(modelBuilder);
        }
    }
}