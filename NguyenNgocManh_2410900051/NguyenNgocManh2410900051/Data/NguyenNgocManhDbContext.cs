using Microsoft.EntityFrameworkCore;
using NguyenNgocManh2410900051.Models;

namespace NguyenNgocManh2410900051.Data;

public class NguyenNgocManhDbContext : DbContext
{
    public NguyenNgocManhDbContext(DbContextOptions<NguyenNgocManhDbContext> options) : base(options) { }

    public DbSet<NguyenNgocManhEmployee> NguyenNgocManhEmployees { get; set; }
    public DbSet<NguyenNgocManhStudent> NguyenNgocManhStudents { get; set; }
}
