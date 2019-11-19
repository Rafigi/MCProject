using Autofac;
using Autofac.Extensions.DependencyInjection;
using McWorld.Shared.Data;
using McWorld.Shared.Factory;
using McWorld.Shared.IRepository;
using McWorld.Shared.Messages;
using McWorld.Shared.Persistence;
using McWorld.Shared.Queryables;
using McWorld.Shared.QueryStack;
using McWorld.Shared.Repository;
using McWorld.Shared.ServicesBus;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace McWorld.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddControllersAsServices();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddDbContext<McDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("McDbConnection")));

            //Now register our services with Autofac container
            var builder = new ContainerBuilder();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            //This is for getting the assembly where Repository Class is hide - McWorld.Shared
            //var dataAccess = Assembly.GetAssembly(typeof(Repository<>));
            //builder.RegisterAssemblyTypes(dataAccess)
            //       .Where(t => t.Name.EndsWith("Repository"))
            //       .AsImplementedInterfaces();
            //builder.RegisterAssemblyTypes(dataAccess)
            //     .Where(t => t.Name.EndsWith("Factory"))
            //     .AsImplementedInterfaces();
            //builder.Populate(services);
            //var container = builder.Build();

            AssemblyLoader.EnsureAllSimuAssembliesAreLoaded();
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<AutofacAutomaticRegistrations>();
            containerBuilder.Populate(services);
            var container = containerBuilder.Build();
            return new AutofacServiceProvider(container);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
