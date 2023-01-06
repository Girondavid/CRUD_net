using Microsoft.EntityFrameworkCore;

namespace CrudApp.UserServices.Infrastructure.DB;

public partial class NominasContext : DbContext
{
    public NominasContext()
    {
    }

    public NominasContext(DbContextOptions<NominasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("User");
    }
}
