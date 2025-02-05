using Microsoft.EntityFrameworkCore;
using AndrewDAL.Models;

namespace AndrewDAL.Migrations
{
    public class SqLiteContext : DbContext
    {
        public DbSet<CmsSectionType> CmsSectionTypes { get; set; }
        public DbSet<CmsSection> CmsSections { get; set; }
        public DbSet<VisitorMessage> VisitorMessages { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public SqLiteContext(DbContextOptions<SqLiteContext> dbContextOptions) : base(dbContextOptions) { }
    }
}
