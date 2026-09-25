using Microsoft.EntityFrameworkCore;
using NnmLesson10EFDbFirst.Models;

namespace NnmLesson10EFDbFirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            var nnmConnection = builder.Configuration.GetConnectionString("NnmK24CNTConnection");
            builder.Services.AddDbContext<NnmK24cnt2lesson10EfdbContext>(
                options => options.UseSqlServer(nnmConnection));

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/NnmHome/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=NnmHome}/{action=NnmIndex}/{id?}");

            app.Run();
        }
    }
}
