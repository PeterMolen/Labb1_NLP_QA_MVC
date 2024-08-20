using Labb1_NLP_QA_MVC.Models;
using Labb1_NLP_QA_MVC.Services;

namespace Labb1_NLP_QA_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Configure Azure Language Service
            builder.Services.Configure<AzureLanguageServiceOptions>(
                builder.Configuration.GetSection("AzureLanguageService"));

            // Register QuestionAnsweringService
            builder.Services.AddSingleton<QuestionAnsweringService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
