using Microsoft.Extensions.DependencyInjection;
using Quizard.Core.Repositories;
using Quizard.Persistence.Repositories;

namespace Quizard.Persistence.DependencyInjection
{
    public static class RepositoriesExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            //Add all repository dependencies here
            services.AddScoped<IQuestionRepository, QuestionRepository>();
        }
    }
}
