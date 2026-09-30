using Microsoft.EntityFrameworkCore;
using NnmLesson12EFCore.Models;

namespace NnmLesson12EFCore.Data;

public class NnmStudentDbContext : DbContext
{
    public NnmStudentDbContext(DbContextOptions<NnmStudentDbContext> options) : base(options)
    {
    }

    public DbSet<NnmStdClass> NnmStdClasses { get; set; }
    public DbSet<NnmStudent> NnmStudents { get; set; }
    public DbSet<NnmSubject> NnmSubjects { get; set; }
    public DbSet<NnmMark> NnmMarks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NnmStudent>().HasIndex(s => s.NnmStudentEmail).IsUnique();
        modelBuilder.Entity<NnmStudent>().HasIndex(s => s.NnmStudentPhone).IsUnique();
        modelBuilder.Entity<NnmSubject>().HasIndex(s => s.NnmSubjectName).IsUnique();

        modelBuilder.Entity<NnmStudent>()
            .HasOne(s => s.NnmClass)
            .WithMany(c => c.NnmStudents)
            .HasForeignKey(s => s.NnmClassId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<NnmMark>().HasKey(m => new { m.NnmSubjectId, m.NnmStudentId });
        modelBuilder.Entity<NnmMark>()
            .HasOne(m => m.NnmStudent)
            .WithMany(s => s.NnmMarks)
            .HasForeignKey(m => m.NnmStudentId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<NnmMark>()
            .HasOne(m => m.NnmSubject)
            .WithMany(s => s.NnmMarks)
            .HasForeignKey(m => m.NnmSubjectId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<NnmStdClass>().HasData(
            new NnmStdClass { Id = 1, NnmClassName = "K24-CNT2" },
            new NnmStdClass { Id = 2, NnmClassName = "K24-CNT1" });
        modelBuilder.Entity<NnmSubject>().HasData(
            new NnmSubject { Id = 1, NnmSubjectName = "ASP.NET Core MVC" },
            new NnmSubject { Id = 2, NnmSubjectName = "Cơ sở dữ liệu" });
        modelBuilder.Entity<NnmStudent>().HasData(
            new NnmStudent { Id = 1, NnmStudentName = "Nguyễn Văn A", NnmStudentEmail = "sinhviena@example.com", NnmStudentPhone = "0900000001", NnmStudentAddress = "Địa chỉ mẫu", NnmStudentAvatar = "student.svg", NnmStudentBirthday = new DateTime(2006, 1, 1), NnmClassId = 1 });
        modelBuilder.Entity<NnmMark>().HasData(
            new NnmMark { NnmSubjectId = 1, NnmStudentId = 1, NnmScore = 8 });
    }
}
