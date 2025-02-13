using AndrewCore.RepositoriesInterfaces;
using AndrewCore.Services.Interfaces;
using AndrewDAL.Repositories;
using AndrewDAL.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.Data.Sqlite;
using System;
using System.IO;
using AndrewCore.Services;
using AndrewDAL.Migrations;

namespace AndrewApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("SqliteContext");

            var builderSql = new SqliteConnectionStringBuilder(connectionString);
            builderSql.DataSource = Path.GetFullPath(
                Path.Combine(
                    AppDomain.CurrentDomain.GetData("DataDirectory") as string
                        ?? AppDomain.CurrentDomain.BaseDirectory,
                    builderSql.DataSource));

            connectionString = builderSql.ToString();

            builder.Services.AddDbContext<SqLiteContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddScoped<ICmsSectionRepository, CmsSectionRepository>();
            builder.Services.AddScoped<ICmsSectionService, CmsSectionService>();
            builder.Services.AddScoped<IVisitorMessageRepository, VisitorMessageRepository.EmailRepository>();
            builder.Services.AddScoped<IVisitorMessageService, EmailService>();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.UseStatusCodePages(async x =>
            {
                if (x.HttpContext.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    x.HttpContext.Response.Redirect("/Error/ErrorPage404");
                }
            });

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

        

        }
    }
}
