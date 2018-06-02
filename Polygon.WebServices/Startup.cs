using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polygon.Data.Repositories;
using Polygon.Domain.Interfaces.Repositories;
using Polygon.Domain.Interfaces.Services.FuncionarioService;
using Polygon.Domain.Interfaces.Services.RegistroService;
using Polygon.Domain.Services;
using Polygon.Services;

namespace Polygon.WebServices
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
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            services.AddTransient<AppRegistroService>();
            services.AddTransient<AppFuncionarioService>();
            services.AddTransient<IFuncionarioService, FuncionarioService>();
            services.AddTransient<IRegistroService, RegistroService>();
            services.AddTransient<IRegistroRepository, RegistroRepository>();
            services.AddTransient<IFuncionarioRepository, FuncionarioRepository>();
       

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("MyPolicy");
            app.UseMvc();
        }
    }
}
