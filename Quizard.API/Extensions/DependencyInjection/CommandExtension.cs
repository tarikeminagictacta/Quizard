using Microsoft.Extensions.DependencyInjection;
using Quizard.Core.Handlers.Command;

namespace Quizard.API.Extensions.DependencyInjection
{
    public static class CommandExtension
    {
        public static void AddCommands(this IServiceCollection services)
        {
            // Add commands here
            services.AddScoped<IAddQuestionCommandHandler, AddQuestionCommandHandler>();
        }
    }
}
