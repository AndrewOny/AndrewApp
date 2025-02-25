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

            // ????????? ????????? ???? ???????? (ContentRootPath)
            var contentRootPath = builder.Environment.ContentRootPath;
            // ???????? ???? ?? ???? ????? ? ????? "databases"
            var databasePath = Path.Combine(contentRootPath, "databases", "Sqlite.db");
            // ????????? ????? ???????????
            var connectionString = $"Data Source={databasePath}";

            // ???????????? DbContext ?? ????????????? SQLite
            builder.Services.AddDbContext<SqLiteContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            // ??????? ???????????? ? appsettings.json
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            // ???????????? AutoMapper
            builder.Services.AddAutoMapper(typeof(Program));

            // ?????????? ???????????
            builder.Services.AddScoped<ICmsSectionRepository, CmsSectionRepository>();
            builder.Services.AddScoped<ICmsSectionService, CmsSectionService>();
            builder.Services.AddScoped<IVisitorMessageRepository, VisitorMessageRepository.EmailRepository>();
            builder.Services.AddScoped<IVisitorMessageService, EmailService>();

            // ??????? ????????? ??????????? ? ????????????
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // ???????????? ??????? ????????? ?????
            app.UseStatusCodePages(async x =>
            {
                if (x.HttpContext.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    x.HttpContext.Response.Redirect("/Error/ErrorPage404");
                }
            });

            // ???????????? ??? ??????????
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            // ?????????????
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
