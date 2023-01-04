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
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__206A9DF87B602F34");

            entity.ToTable("User");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("User_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
