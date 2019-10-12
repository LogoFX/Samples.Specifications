using JetBrains.Annotations;
using LogoFX.Server.Bootstrapping.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Solid.Bootstrapping;
using BootstrapperBase = LogoFX.Server.Bootstrapping.BootstrapperBase;

namespace Samples.Specifications.Server.Facade
{
    internal sealed class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        [UsedImplicitly]
        public IConfiguration Configuration { get; }

        [UsedImplicitly]
        public void ConfigureServices(IServiceCollection services)
        {
            var bootstrapper = new Bootstrapper(services)
                .Use(new RegisterCustomCompositionModulesMiddleware<BootstrapperBase, IServiceCollection>())
                .Use(new RegisterCoreMiddleware<BootstrapperBase>())
                .Use(new RegisterControllersMiddleware<BootstrapperBase>());
            bootstrapper.Initialize();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [UsedImplicitly]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}