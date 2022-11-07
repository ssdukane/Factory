using Admin;
using Dashboard;
using Factory.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Omi.Application.Configuration;
using Omi.Infra;
using System.IO.Compression;
using System.Linq;
using Users.API;

namespace Factory.v2
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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            //To use to generate Documnetaion need below lines Upadted by Balaji
            services.AddSwaggerGen(c =>
            {
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.IgnoreObsoleteActions();
                c.IgnoreObsoleteProperties();
                c.CustomSchemaIds(type => type.FullName);
            });

            // Strat Balaji Added below global declaraition insted of mentioned in each method or in each verb
            services.AddMvc(options =>
            {
                options.Filters.Add(new ProducesAttribute("application/json"));
            });
            // End Balaji change


            //Adding GZIP compressed response. As compressed response improves API performance
            services.AddResponseCompression(options =>
                {
                    options.EnableForHttps = true;
                    options.Providers.Add<GzipCompressionProvider>();
                });

            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });

            services.AddScoped<Factory>();

            services.AddScoped<UserManager>()
                .AddScoped<IInvoke, UserManager>(s => s.GetService<UserManager>());
            services.AddScoped<AdminManager>()
               .AddScoped<IInvoke, AdminManager>(s => s.GetService<AdminManager>());
            services.AddScoped<DashboardManager>()
                .AddScoped<IInvoke, DashboardManager>(s => s.GetService<DashboardManager>());

            services.AddInfraServices(_configuration);

            services.AddControllers();
            services.AddControllers().AddXmlSerializerFormatters();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            //Balaji has upadted below lines for Swagger
            //  app.UseSwagger(c => c.RouteTemplate = "udmsapi/swagger/v1/swagger.json");
            //  app.UseSwaggerUI();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "UDMS API 1.0.0");
                //c.SwaggerEndpoint("./v1/swagger.json", "UDMS API 1.0.0"); //originally "./swagger/v1/swagger.json"
            });

            //services.AddSwaggerGen();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "UDMS System", Version = "v1" });
            //    //c.SwaggerDoc("v1", new OpenApiInfo
            //    //{
            //    //    Version = "v1.0.0",
            //    //    Title = "UDMS API's",
            //    //    Description = "UDMS System",
            //    //    //TermsOfService = new Uri("https://localhost:44332/swagger/v1/swagger.json"),
            //    //    TermsOfService = new Uri("https://localhost:44332"),
            //    //    Contact = new OpenApiContact
            //    //    {
            //    //        //Name = "UDMS API details in Json format",
            //    //        //Url = new Uri("https://localhost:44332/swagger/v1/swagger.json")
            //    //    }
            //    //});
            //});
            //Change End
        }
    }
}