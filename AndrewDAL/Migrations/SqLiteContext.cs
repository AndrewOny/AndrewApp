using Microsoft.EntityFrameworkCore;
using AndrewDAL.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.Sqlite;

namespace AndrewDAL.Migrations
{
    public class SqLiteContext : DbContext
    {
        public DbSet<CmsSectionType> CmsSectionTypes { get; set; }
        public DbSet<CmsSection> CmsSections { get; set; }
        public DbSet<VisitorMessage> VisitorMessages { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public SqLiteContext(DbContextOptions<SqLiteContext> dbContextOptions) : base(dbContextOptions) { }
        public SqLiteContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");
            var sqliteBuilder = new SqliteConnectionStringBuilder(connectionString);
            sqliteBuilder.DataSource = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, sqliteBuilder.DataSource);

            optionsBuilder.UseSqlite(sqliteBuilder.ToString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CmsSectionType>()
                        .HasMany(sectionType => sectionType.CmsSections)
                        .WithOne(cmsSection => cmsSection.CmsSectionType)
                        .HasForeignKey(e => e.CmsSectionTypeId)
                        .IsRequired();


            modelBuilder.Entity<AdminUser>()
                        .HasIndex(p => p.Login)
                        .IsUnique();

            modelBuilder.Entity<AdminUser>()
                        .HasIndex(p => p.Email)
                        .IsUnique();

            modelBuilder.Entity<AdminUser>()
                        .HasIndex(p => p.Password)
                        .IsUnique();

            modelBuilder.Entity<ContactForm>(c =>
            {
                c.HasData(new ContactForm
                {
                    Id = 1,
                    NameLabel = "Name",
                    NamePlaceholder = "Enter your name",
                    EmailLabel = "Email",
                    EmailPlaceholder = "Enter your email",
                    TitleLabel = "Title",
                    TitlePlaceholder = "Enter the title",
                    MessageLabel = "Message",
                    MessagePlaceholder = "Enter your message"
                });
            });

            modelBuilder.Entity<AdminUser>(c =>
            {
                c.HasData(new AdminUser
                {
                    Id = 1,
                    Login = "admin",
                    Password = "admin",
                    Email = "admin@gmail.com"
                }
                );
            });
        }
    }
}
