using Microsoft.EntityFrameworkCore;
using NguyenNgocManh2410900051.Models;

namespace NguyenNgocManh2410900051.Data;

public class ExamDbContext : DbContext
{
    public ExamDbContext(DbContextOptions<ExamDbContext> options) : base(options) { }

    public DbSet<NguyenNgocManhEmployee> NguyenNgocManhEmployees { get; set; }
    public DbSet<NguyenNgocManhStudent> NguyenNgocManhStudents { get; set; }
}
