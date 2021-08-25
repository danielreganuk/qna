using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Qna.Api.Extensions;
using Qna.Application.Infrastructure;
using Qna.Application.Interfaces;
using Qna.Application.Questions.Queries.GetQuestionsList;
using Qna.Persistence;
using System.Reflection;
using Qna.Application.Authors.Queries.GetAuthorByEmailAddress;
using Qna.Persistence.Initialisers;

namespace Qna.Api
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Qna.Api", Version = "v1" });
            });
            services.AddConfiguredDbContext(Configuration);
            services.AddScoped<IDatabaseContext>(s => s.GetService<DatabaseContext>());
            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });
            services.AddMediatR(typeof(GetAuthorByEmailAddressQuery).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DatabaseContext ctx)
        {
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Qna.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ctx.Database.Migrate();
            app.UseDeveloperExceptionPage();

            DevelopmentInit.Init(ctx);
        }
    }
}