using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NnmLesson12EFCore.Data;

#nullable disable

namespace NnmLesson12EFCore.Migrations.App
{
    [DbContext(typeof(NnmAppDbContext))]
    [Migration("20260930051630_NnmCreateCatalog")]
    partial class NnmCreateCatalog
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NnmLesson12EFCore.Models.NnmBanner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("NnmCreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NnmDescription")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("NnmImage")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("NnmName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<byte>("NnmStatus")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("NnmBanner");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NnmCreatedDate = new DateTime(2026, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            NnmDescription = "Nguyễn Ngọc Mạnh - 2410900051 - K24-CNT2",
                            NnmImage = "lesson12.svg",
                            NnmName = "Chào mừng đến với Lesson12",
                            NnmStatus = (byte)1
                        });
                });

            modelBuilder.Entity("NnmLesson12EFCore.Models.NnmCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("NnmCreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NnmName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte>("NnmStatus")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("NnmCategory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NnmCreatedDate = new DateTime(2026, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            NnmName = "Sách",
                            NnmStatus = (byte)1
                        },
                        new
                        {
                            Id = 2,
                            NnmCreatedDate = new DateTime(2026, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            NnmName = "Đồ dùng học tập",
                            NnmStatus = (byte)1
                        });
                });

            modelBuilder.Entity("NnmLesson12EFCore.Models.NnmProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NnmCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("NnmCreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NnmDescriptions")
                        .HasMaxLength(1000)
                        .HasColumnType("ntext");

                    b.Property<string>("NnmImage")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("NnmName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<float>("NnmPrice")
                        .HasColumnType("real");

                    b.Property<float>("NnmSalePrice")
                        .HasColumnType("real");

                    b.Property<byte>("NnmStatus")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("NnmCategoryId");

                    b.ToTable("NnmProduct");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NnmCategoryId = 2,
                            NnmCreatedDate = new DateTime(2026, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            NnmDescriptions = "Sổ tay dùng để ghi chép bài học.",
                            NnmImage = "notebook.svg",
                            NnmName = "Sổ tay",
                            NnmPrice = 45000f,
                            NnmSalePrice = 39000f,
                            NnmStatus = (byte)1
                        },
                        new
                        {
                            Id = 2,
                            NnmCategoryId = 1,
                            NnmCreatedDate = new DateTime(2026, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            NnmDescriptions = "Sách tham khảo lập trình.",
                            NnmImage = "book.svg",
                            NnmName = "Sách lập trình",
                            NnmPrice = 150000f,
                            NnmSalePrice = 0f,
                            NnmStatus = (byte)1
                        });
                });

            modelBuilder.Entity("NnmLesson12EFCore.Models.NnmProduct", b =>
                {
                    b.HasOne("NnmLesson12EFCore.Models.NnmCategory", "NnmCategory")
                        .WithMany("NnmProducts")
                        .HasForeignKey("NnmCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("NnmCategory");
                });

            modelBuilder.Entity("NnmLesson12EFCore.Models.NnmCategory", b =>
                {
                    b.Navigation("NnmProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
