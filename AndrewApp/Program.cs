using AndrewCore.RepositoriesInterfaces;
using AndrewCore.Services.Interfaces;
using AndrewDAL.Migrations;
using AndrewDAL.Repositories;
using AutoMapper;
using System;
using Microsoft.EntityFrameworkCore;
using AndrewDAL.Models;
using AndrewDAL.Mapping;
using Microsoft.Data.Sqlite;

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

            // Add services to the container.
            builder.Services.AddControllersWithViews();


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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

