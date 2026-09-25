using Microsoft.EntityFrameworkCore;

namespace NnmLesson10EFDbFirst.Models;

public partial class NnmK24cnt2lesson10EfdbContext : DbContext
{
    public NnmK24cnt2lesson10EfdbContext()
    {
    }

    public NnmK24cnt2lesson10EfdbContext(DbContextOptions<NnmK24cnt2lesson10EfdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<NnmMember> NnmMembers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NnmMember>(entity =>
        {
            entity.ToTable("NnmMember");

            entity.Property(e => e.NnmEmail)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.NnmFullName)
                .HasMaxLength(50);

            entity.Property(e => e.NnmPassword)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.NnmPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.NnmUserName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
