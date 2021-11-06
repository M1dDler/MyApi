using Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MyApiDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }

        public MyApiDbContext(DbContextOptions<MyApiDbContext> options) : base(options)
        {

        }


        public async Task CommitAsync()
        {
            await this.SaveChangesAsync(cancellationToken: default);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(b =>
            {
                b.HasKey(x => x.Id);
                b.HasMany(x => x.Groups)
                    .WithMany(u => u.User);
                b.HasIndex(x => x.Name)
                    .IsUnique();
            });

            modelBuilder.Entity<Group>(b =>
            {
                b.HasKey(x => x.Id);
                b.HasMany(x => x.User)
                    .WithMany(u => u.Groups);
                b.HasIndex(x => x.Name)
                    .IsUnique();
            });
        }

    }
}
