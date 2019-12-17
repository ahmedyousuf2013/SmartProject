using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using SmartProject.Data;
using SmartProject.Models;
using SmartProject.Repository;
using SmartProject.Services;
using SmartProject.UserManagement.Models;
using Swashbuckle.AspNetCore.Swagger;
using IEmailSender = SmartProject.Services.IEmailSender;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.SpaServices.AngularCli;

namespace SmartProject
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
            services.AddControllers().AddNewtonsoftJson();
            services.ConfigureSQLContext(Configuration);
            services.ConfigureJwtBearer(Configuration);
            services.AddMvc();
            services.ConfigureCors();
            services.ConfigureIISIntegration();
            services.AddControllersWithViews();
            services.ConfigureRepositoryContainer();
            services.ConfigureRepositoryWrapper();
            services.AddControllers();
            services.AddRazorPages();
            services.ConfigurePassword();
            services.ConfigureApplicationCookie();
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .ConfigureApplicationPartManager(apm =>
            {
                var dependentLibrary = apm.ApplicationParts
                    .FirstOrDefault(part => part.Name == "SmartProject.UserManagement"||part.Name== "SmartProject.API");
            });

            //////
            //services.AddSwaggerGen(c => {
            //    c.SwaggerDoc("v1", new Info
            //    {
            //        Version = "v1",
            //        Title = "My First API",
            //        Description = "My First ASP.NET Core 2.0 Web API",
            //        TermsOfService = "None",
            //        Contact = new Contact()
            //        {
            //            Name = "Neel Bhatt",
            //            Email = "neel.bhatt40@gmail.com",
            //            Url = "https://neelbhatt40.wordpress.com/"
            //        }
            //    });
            //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {

            //////
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                    spa.Options.StartupTimeout = TimeSpan.FromSeconds(1000);
                }
            });


            /////////////
            SeedDB.Initialize(app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider);

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            /////////////
            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseEndpoints(endpoints =>
            {


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });
            ////Swagger
            //app.UseSwagger();
            //app.UseSwaggerUI(c => {
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            //});
            CreateUserRoles(services).Wait();
        }

        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();


            IdentityResult roleResult;
            //Adding Addmin Role
            var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck)
            {
                //create the roles and seed them to the database
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
            }
            //Asign Admin role to the main User here i have given my login id for Admin management
            ApplicationUser user = await UserManager.FindByEmailAsync("goldena91@gmail.com");
            var User = new ApplicationUser();
            await UserManager.AddToRoleAsync(user, "Admin");

        }
    }
}
