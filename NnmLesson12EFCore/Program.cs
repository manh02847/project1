using Microsoft.EntityFrameworkCore;
using NnmLesson12EFCore.Data;

namespace NnmLesson12EFCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<NnmAppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("NnmAppConnection")));
        builder.Services.AddDbContext<NnmStudentDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("NnmStudentConnection")));

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
