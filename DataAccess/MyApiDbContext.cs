using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class MyApiDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conn = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(conn);
        }
    }
}
