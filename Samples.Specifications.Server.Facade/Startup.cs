using LogoFX.Server.Bootstrapping;
using LogoFX.Server.Bootstrapping.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Samples.Specifications.Server.Facade
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to bootstrap the services registration
        public void ConfigureServices(IServiceCollection services) => new Bootstrapper(services)
            .UseCompositionModules<BootstrapperBase, IServiceCollection>()
            .Use(new RegisterCoreMiddleware<BootstrapperBase>())
            .Use(new RegisterControllersMiddleware<BootstrapperBase>()).Initialize();

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app
                .UseHttpsRedirection()
                .UseCors("AllowAny")
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                })
                .UseMvc();
        }
    }
}
