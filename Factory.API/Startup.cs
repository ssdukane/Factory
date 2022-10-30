using Admin;
using Dashboard;
using Factory.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Omi.Application.Configuration;
using Omi.Infra;
using Users.API;

namespace Factory.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationOptions _options;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            //_options = _configuration.Get<ApplicationOptions>();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<Factory>();

            services.AddScoped<UserManager>()
                .AddScoped<IInvoke, UserManager>(s => s.GetService<UserManager>());
            services.AddScoped<AdminManager>()
               .AddScoped<IInvoke, AdminManager>(s => s.GetService<AdminManager>());
            services.AddScoped<DashboardManager>()
                .AddScoped<IInvoke, DashboardManager>(s => s.GetService<DashboardManager>());

            services.AddInfraServices(_configuration);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Factory API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
