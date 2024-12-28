using Microsoft.EntityFrameworkCore;
using portfolio_api.Models;

namespace portfolio_api.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions): base(dbContextOptions) 
        {}
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
    }
}