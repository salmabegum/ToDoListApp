using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApp;
using ToDoListApp.Contexts;
using ToDoListApp.Models;
using ToDoListApp.Repositories;

namespace ToDoListApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        string GetRemoteConnectionString()
        {
            string databaseUrl =Configuration["Database_URL"];
            Uri uri = new Uri(databaseUrl);
            return $"host={uri.Host};username={uri.UserInfo.Split(':')[0]}; password={uri.UserInfo.Split(':')[1]};database={uri.LocalPath.Substring(1)};pooling=true;SSl Mode=Require;TrustServerCertificate=True;";
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<ApplicationDbContext>(options =>
                {
                    // options.UseSqlServer(Configuration.GetConnectionString("localSqlServerConnection"));
                    options.UseNpgsql(GetRemoteConnectionString());
            });
            services.AddTransient<IRepository<GroceryItem>, ToDoItemRepository>();
            services.AddTransient<IRepository<Category>, CategoryRepository>();


            //services.AddTransient<ITodoItemRepository, MockTodoItemRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
                app.UseDeveloperExceptionPage();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
