using Microsoft.EntityFrameworkCore;
using OAuthOidc.Data.Users;

namespace OAuthOidc.Data.DbContexts
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
