using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PycWebApi.Middleware;

namespace PycWebApi
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

            // services
            services.AddSingleton<SingletonService>();
            services.AddScoped<ScopedService>();
            services.AddTransient<TransientService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PycWebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PycWebApi v1"));
            }

            // middleware
            app.UseMiddleware<HeartbeatMiddleware>();
            app.UseMiddleware<ErrorHandlerMiddleware>();
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.Use((ctx, next) =>
            {
                // Get all the services and increase their counters...
                var singleton = ctx.RequestServices.GetRequiredService<SingletonService>();
                var scoped = ctx.RequestServices.GetRequiredService<ScopedService>();
                var transient = ctx.RequestServices.GetRequiredService<TransientService>();

                singleton.Counter++;
                scoped.Counter++;
                transient.Counter++;

                return next();
            });
            app.Run(async ctx =>
            {
                // ...then do it again...
                var singleton = ctx.RequestServices.GetRequiredService<SingletonService>();
                var scoped = ctx.RequestServices.GetRequiredService<ScopedService>();
                var transient = ctx.RequestServices.GetRequiredService<TransientService>();

                singleton.Counter++;
                scoped.Counter++;
                transient.Counter++;

                // ...and display the counter values.
                await ctx.Response.WriteAsync($"Singleton: {singleton.Counter}\n");
                await ctx.Response.WriteAsync($"Scoped: {scoped.Counter}\n");
                await ctx.Response.WriteAsync($"Transient: {transient.Counter}\n");
            });
        }
    }
}
