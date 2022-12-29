using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SampleProject.Repository;
using SampleProject.Repository.Interfaces;

namespace SampleProject.Api
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        private IConfiguration _configuration { get; }
        private static string _connectionString { get; set; }

        //[Obsolete]
        //private IHostingEnvironment _environment;
        private static string _Gen_connectionString { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Configuration = configuration;
            var builder = new ConfigurationBuilder()
                            .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                            .AddJsonFile("AppSettings.json");

            _configuration = builder.Build();
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
            _Gen_connectionString = _configuration.GetConnectionString("GeneralConnection");
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors();
            services.AddTransient<IUserRepository>(c => new UserService(_connectionString));
            services.AddTransient<IStudentRepository>(c => new StudentService(_connectionString));
            //To use app.UseMvc() we need this code part. 
            services.AddMvc(options=>options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            // Enable authentication capabilities

            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

            _ = app.UseMvc();
        }
    }
}
