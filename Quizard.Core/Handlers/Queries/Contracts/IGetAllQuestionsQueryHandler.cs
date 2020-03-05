using Quizard.Core.Handlers.Queries.Contracts.Base;
using Quizard.Core.Models.Domain;
using Quizard.Core.Models.Dto;
using Quizard.Core.Models.Query;

namespace Quizard.Core.Handlers.Queries.Contracts
{
    public interface IGetAllQuestionsQueryHandler:IQueryHandler<GetAllQuestionsQuery, PagedResult<Question>>
    {
    }
}
