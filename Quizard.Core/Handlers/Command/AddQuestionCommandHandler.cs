using System.Linq;
using System.Threading.Tasks;
using Quizard.Core.Models.Command;
using Quizard.Core.Models.Domain;
using Quizard.Core.Repositories;

namespace Quizard.Core.Handlers.Command
{
    public class AddQuestionCommandHandler:IAddQuestionCommandHandler

    {
        private readonly IQuestionRepository _questionRepository;

        public AddQuestionCommandHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<Question> AddQuestion(AddQuestionCommand command)
        {
            var answers = command.Answers.Select(x => new Answer(x.Text, x.IsCorrect)).ToList();
            var question = new Question(command.Text, answers);

            return await _questionRepository.AddQuestion(question);
        }
    }
}
