using System.Threading.Tasks;
using Quizard.Core.Handlers.Queries.Contracts;
using Quizard.Core.Models.Domain;
using Quizard.Core.Models.Dto;
using Quizard.Core.Models.Query;
using Quizard.Core.Repositories;

namespace Quizard.Core.Handlers.Queries
{
    public class GetAllQuestionsQueryHandler : IGetAllQuestionsQueryHandler
    {
        private readonly IQuestionRepository _questionRepository;

        public GetAllQuestionsQueryHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        public async Task<PagedResult<Question>> Handle(GetAllQuestionsQuery query)
        {
            return await _questionRepository.GetAll(query.PageNumber, query.PageSize);
        }
    }
}