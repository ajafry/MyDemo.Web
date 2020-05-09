using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using My.Demo.Data;
using My.Demo.Query.Services;
using My.Demo.Command.Services;
using My.Demo.Query.Services.InMemory;
using My.Demo.Command.Services.InMemory;
using My.Demo.Data.Postgres;
using Microsoft.EntityFrameworkCore;

namespace My.Demo.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("MovieDbConnection");
            services.AddDbContext<MovieDbContext>(options => 
                options.UseNpgsql(connectionString)
                .EnableSensitiveDataLogging(), 
                ServiceLifetime.Transient);
            services.AddTransient<IMovieQueryService, My.Demo.Query.Services.DB.MovieQueryService>();
            services.AddTransient<IPrincipalQueryService, My.Demo.Query.Services.DB.PrincipalQueryService>();
            services.AddSingleton<IMovieCommandService, MovieCommandService>();
            services.AddSingleton<IPrincipalCommandService, PrincipalCommandService>();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
