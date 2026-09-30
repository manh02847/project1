using Microsoft.EntityFrameworkCore;
using NnmLesson12EFCore.Models;

namespace NnmLesson12EFCore.Data;

public class NnmAppDbContext : DbContext
{
    public NnmAppDbContext(DbContextOptions<NnmAppDbContext> options) : base(options)
    {
    }

    public DbSet<NnmCategory> NnmCategories { get; set; }
    public DbSet<NnmProduct> NnmProducts { get; set; }
    public DbSet<NnmBanner> NnmBanners { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NnmProduct>()
            .HasOne(p => p.NnmCategory)
            .WithMany(c => c.NnmProducts)
            .HasForeignKey(p => p.NnmCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        var date = new DateTime(2026, 9, 30, 8, 0, 0);
        modelBuilder.Entity<NnmCategory>().HasData(
            new NnmCategory { Id = 1, NnmName = "Sách", NnmStatus = 1, NnmCreatedDate = date },
            new NnmCategory { Id = 2, NnmName = "Đồ dùng học tập", NnmStatus = 1, NnmCreatedDate = date });
        modelBuilder.Entity<NnmProduct>().HasData(
            new NnmProduct { Id = 1, NnmName = "Sổ tay", NnmImage = "notebook.svg", NnmPrice = 45000, NnmSalePrice = 39000, NnmStatus = 1, NnmDescriptions = "Sổ tay dùng để ghi chép bài học.", NnmCategoryId = 2, NnmCreatedDate = date },
            new NnmProduct { Id = 2, NnmName = "Sách lập trình", NnmImage = "book.svg", NnmPrice = 150000, NnmSalePrice = 0, NnmStatus = 1, NnmDescriptions = "Sách tham khảo lập trình.", NnmCategoryId = 1, NnmCreatedDate = date });
        modelBuilder.Entity<NnmBanner>().HasData(
            new NnmBanner { Id = 1, NnmName = "Chào mừng đến với Lesson12", NnmImage = "lesson12.svg", NnmDescription = "Nguyễn Ngọc Mạnh - 2410900051 - K24-CNT2", NnmStatus = 1, NnmCreatedDate = date });
    }
}
