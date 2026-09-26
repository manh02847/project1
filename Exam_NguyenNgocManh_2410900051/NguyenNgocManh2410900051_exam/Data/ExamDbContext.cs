using Microsoft.EntityFrameworkCore;
using NguyenNgocManh2410900051_exam.Models;

namespace NguyenNgocManh2410900051_exam.Data;

public class ExamDbContext : DbContext
{
    public ExamDbContext(DbContextOptions<ExamDbContext> options) : base(options) { }

    public DbSet<NguyenNgocManhEmployee> NguyenNgocManhEmployees { get; set; }
    public DbSet<NguyenNgocManhStudent> NguyenNgocManhStudents { get; set; }
}
