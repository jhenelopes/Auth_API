using Microsoft.EntityFrameworkCore;
using auth_api.Model;

namespace auth_api.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(
            "Server=localhost;" +   
            "Port=5432;Database=letshare_assessment;" +
            "User Id=postgres;" +
            "Password=12345"
          );
    }
}
