using Microsoft.Extensions.DependencyInjection;
using Quizard.Core.Handlers.Queries;
using Quizard.Core.Handlers.Queries.Contracts;

namespace Quizard.API.Extensions.DependencyInjection
{
    public static class QueryExtension
    {
        public static void AddQueries(this IServiceCollection services)
        {
            // Add queries here
            services.AddScoped<IGetAllQuestionsQueryHandler, GetAllQuestionsQueryHandler>();
            services.AddScoped<IGetQuestionQueryHandler, GetQuestionQueryHandler>();

        }
    }
}
