using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NnmLesson12EFCore.Data;

#nullable disable

namespace NnmLesson12EFCore.Migrations.Student
{
    [DbContext(typeof(NnmStudentDbContext))]
    [Migration("20260930051636_NnmCreateStudentManager")]
    partial class NnmCreateStudentManager
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NnmLesson12EFCore.Models.NnmMark", b =>
                {
                    b.Property<int>("NnmSubjectId")
                        .HasColumnType("int");

                    b.Property<int>("NnmStudentId")
                        .HasColumnType("int");

                    b.Property<double>("NnmScore")
                        .HasColumnType("float");

                    b.HasKey("NnmSubjectId", "NnmStudentId");

                    b.HasIndex("NnmStudentId");

                    b.ToTable("NnmMarks");

                    b.HasData(
                        new
                        {
                            NnmSubjectId = 1,
                            NnmStudentId = 1,
                            NnmScore = 8.0
                        });
                });

            modelBuilder.Entity("NnmLesson12EFCore.Models.NnmStdClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NnmClassName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("NnmStdClass");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NnmClassName = "K24-CNT2"
                        },
                        new
                        {
                            Id = 2,
                            NnmClassName = "K24-CNT1"
                        });
                });

            modelBuilder.Entity("NnmLesson12EFCore.Models.NnmStudent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NnmClassId")
                        .HasColumnType("int");

                    b.Property<string>("NnmStudentAddress")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("NnmStudentAvatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("NnmStudentBirthday")
                        .HasColumnType("date");

                    b.Property<string>("NnmStudentEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NnmStudentName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NnmStudentPhone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("NnmClassId");

                    b.HasIndex("NnmStudentEmail")
                        .IsUnique();

                    b.HasIndex("NnmStudentPhone")
                        .IsUnique();

                    b.ToTable("NnmStudent");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NnmClassId = 1,
                            NnmStudentAddress = "Địa chỉ mẫu",
                            NnmStudentAvatar = "student.svg",
                            NnmStudentBirthday = new DateTime(2006, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NnmStudentEmail = "sinhviena@example.com",
                            NnmStudentName = "Nguyễn Văn A",
                            NnmStudentPhone = "0900000001"
                        });
                });

            modelBuilder.Entity("NnmLesson12EFCore.Models.NnmSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NnmSubjectName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("NnmSubjectName")
                        .IsUnique();

                    b.ToTable("NnmSubjects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NnmSubjectName = "ASP.NET Core MVC"
                        },
                        new
                        {
                            Id = 2,
                            NnmSubjectName = "Cơ sở dữ liệu"
                        });
                });

            modelBuilder.Entity("NnmLesson12EFCore.Models.NnmMark", b =>
                {
                    b.HasOne("NnmLesson12EFCore.Models.NnmStudent", "NnmStudent")
                        .WithMany("NnmMarks")
                        .HasForeignKey("NnmStudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("NnmLesson12EFCore.Models.NnmSubject", "NnmSubject")
                        .WithMany("NnmMarks")
                        .HasForeignKey("NnmSubjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("NnmStudent");

                    b.Navigation("NnmSubject");
                });

            modelBuilder.Entity("NnmLesson12EFCore.Models.NnmStudent", b =>
                {
                    b.HasOne("NnmLesson12EFCore.Models.NnmStdClass", "NnmClass")
                        .WithMany("NnmStudents")
                        .HasForeignKey("NnmClassId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("NnmClass");
                });

            modelBuilder.Entity("NnmLesson12EFCore.Models.NnmStdClass", b =>
                {
                    b.Navigation("NnmStudents");
                });

            modelBuilder.Entity("NnmLesson12EFCore.Models.NnmStudent", b =>
                {
                    b.Navigation("NnmMarks");
                });

            modelBuilder.Entity("NnmLesson12EFCore.Models.NnmSubject", b =>
                {
                    b.Navigation("NnmMarks");
                });
#pragma warning restore 612, 618
        }
    }
}
