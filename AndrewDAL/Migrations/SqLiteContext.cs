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
    }
}
