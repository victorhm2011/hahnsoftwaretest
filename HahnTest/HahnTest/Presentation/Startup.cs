using FluentValidation;
using HahnTest.Application.Validators;
using HahnTest.Domain.Repositories;
using HahnTest.Domain.Services;
using HahnTest.Presentation.DTOs;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace HahnTest.Presentation
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
            services.AddControllers(options =>
            {
                options.Filters.Add(new ApiExceptionFilter());
            })
            .AddFluentValidation();

            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IBookRepository, BookRepository>();

            services.AddTransient<IValidator<BookDto>, BookValidator>();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
