using System.Threading.Tasks;
using Quizard.Core.Handlers.Queries.Contracts;
using Quizard.Core.Models.Domain;
using Quizard.Core.Models.Query;
using Quizard.Core.Repositories;

namespace Quizard.Core.Handlers.Queries
{
    public class GetQuestionQueryHandler : IGetQuestionQueryHandler
    {
        private readonly IQuestionRepository _questionRepository;

        public GetQuestionQueryHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<Question> Handle(GetQuestionQuery query)
        {
            return await _questionRepository.GetById(query.Id);
        }
    }
}