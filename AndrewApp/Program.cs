using AutoMapper;

namespace AndrewApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //#region Dependency Injection
            //var config = new MapperConfiguration(c => {
            //    c.AddProfile<QueryableDatabaseMapperProfile>();
            //    c.AddProfile<MvcMapperProfile>();
            //});

            //builder.Services.AddSingleton<IMapper>(s => config.CreateMapper());
            //// Add services to the container.

            //builder.Services.AddDbContext<MsSqlContext>(options =>
            //{
            //    string? connectionString = builder.Configuration.GetConnectionString("MsSqlContext");
            //    options.UseSqlServer(connectionString);
            //    //options.UseSqlServer(builder.Configuration.GetConnectionString("MsSqlContext"));
            //});
            //config.AssertConfigurationIsValid();
            //builder.Services.AddTransient<IBuildingsRepository, BuildingsRepository>();
            //builder.Services.AddTransient<IBuildingsService, BuildingsService>();
            //#endregion

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
