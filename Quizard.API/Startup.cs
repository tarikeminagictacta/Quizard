using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag;
using Quizard.API.Extensions.DependencyInjection;
using Quizard.Persistence;
using Quizard.Persistence.DependencyInjection;

namespace Quizard.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlServer(
                        Configuration.GetConnectionString("QuizardDb"), x => x.MigrationsAssembly(typeof(ApplicationDbContext).AssemblyQualifiedName));
                }
            );
            services.AddSwaggerDocument(config => 
                config.PostProcess = document =>
                {
                    document.Info = new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Quizard.Api",
                        Description = "Api added for quizard - quiz api",
                        TermsOfService = "None",
                        Contact = new OpenApiContact
                        {
                            Name = "Tacta interns",
                            Email = "interns@tacta.io",
                            Url = "https://tacta.io/"
                        },
                        License = new OpenApiLicense
                        {
                            Name = "MIT",
                            Url = "https://opensource.org/licenses/MIT"
                        }
                    };
                });
            services.AddQueries();
            services.AddCommands();
            services.AddRepositories();
            services.AddAutoMapper(typeof(ApplicationDbContext).Assembly);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
