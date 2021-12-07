using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using TemalabBackend.DAL.EF;
using TemalabBackend.DAL;
using TemalabBackend.BL;


namespace TemalabBackend
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

            services.AddDbContext<ToDoDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Temalab")));
            //(opt => opt.UseInMemoryDatabase("TemalabTesztelo"));


            services.AddTransient<IToDoItemRepository, ToDoItemRepository>();

            services.AddTransient<IToDoManager, ToDoManager>();

            services.AddControllers();
            /*services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TemalabBackend", Version = "v1" });
            });*/

            services.AddCors(opt =>
            {
                opt.AddPolicy("policy", builder =>
                {
                    builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
                });
            });

            /*services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                                  });
            });*/

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TemalabBackend v1"));
            }
            //app.UseCors("pls");
            //app.UseHttpsRedirection();

            //app.UseCors("pls");

            //app.UseHttpLogging();

            app.UseRouting();

            app.UseCors("policy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
