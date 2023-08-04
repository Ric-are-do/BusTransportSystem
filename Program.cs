using BusServiceApplication.Data;
using BusServiceApplication.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

namespace BusServiceApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Creating a variable and stroing the connection string in it 
            // Below we validate the connection string and throw an exception if I cannot find it
            var connectionString = builder.Configuration.GetConnectionString("Default")
            ?? throw new NullReferenceException("No connection string found in Default object");

            //Register our services here 
            builder.Services.AddTransient<LoginPageService>();
            builder.Services.AddTransient<AdministratorServices>();
            builder.Services.AddTransient<StudentService>();
            builder.Services.AddTransient<BusRoutServices>();
            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();
            // adding our DBcontext as a service that we can call for dependency injection
            builder.Services.AddDbContextFactory<ProjectDbContext>((DbContextOptionsBuilder options) =>
            options.UseSqlServer(connectionString));
            


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}