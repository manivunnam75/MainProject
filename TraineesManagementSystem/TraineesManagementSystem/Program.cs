using Microsoft.EntityFrameworkCore;
using TraineesManagementSystem.Repositary;
using TraineesManagementSystem.Repositary.Context;
using TraineesManagementSystem.Services;
using TraineesManagementSystem.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;

namespace TraineesManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connection = builder.Configuration.GetConnectionString("con");
         //   builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddDbContext<TraineeDbContext>(options => 
            { options.UseSqlServer(connection); });

           
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ITraineeService,TraineeService>();
            builder.Services.AddScoped<ITraineeRepository, TraineeRepository>();
            



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=TraineeDetails}/{id?}");

            app.Run();
        }
    }
}