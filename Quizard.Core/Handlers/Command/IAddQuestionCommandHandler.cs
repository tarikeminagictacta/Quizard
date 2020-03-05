using System.Threading.Tasks;
using Quizard.Core.Models.Command;
using Quizard.Core.Models.Domain;

namespace Quizard.Core.Handlers.Command
{
    public interface IAddQuestionCommandHandler
    {
        Task<Question> AddQuestion(AddQuestionCommand command);
    }
}
