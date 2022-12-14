using GerenciaFOOD_API.Configuration;
using GerenciaFOOD_API.Controllers;
using GerenciaFood_Services.Helpers;
using Hangfire;
using Hangfire.MemoryStorage;
using Hangfire.Server;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;


namespace GerenciaFOOD_API
{
    public class Startup
    {
        private readonly IBackgroundProcessingServer _server;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IBackgroundProcessingServer, BackgroundProcessingServer>();

            var urlsApis = Configuration.GetSection("UrlsApis");
            services.Configure<UrlsApis>(urlsApis);
            

            services.AddControllers();
            services.AddIoCServices();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GerenciaFOOD_API", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://192.168.137.1:4200");
                                  });
            });

            services.AddHangfire(op =>
                {
                    op.UseMemoryStorage();
                }
            );
            services.AddHangfireServer();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GerenciaFOOD_API v1"));
            }

            var controllerProduct = new ProdutosController();

            app.UseHttpsRedirection();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseHangfireDashboard();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


        public async Task RestartHangFireServer(IApplicationBuilder app)
        {
            await Task.Run(async () =>
            {
                _server.SendStop();
                await _server.WaitForShutdownAsync(new System.Threading.CancellationToken());
                _server.Dispose();

                app.UseHangfireServer(new BackgroundJobServerOptions
                {
                    WorkerCount = 1,
                    Queues = new[] { "customqueuename" },
                    ServerName = "API NFSe V2 Hangfireserver",
                });
            });
        }


    }
}
