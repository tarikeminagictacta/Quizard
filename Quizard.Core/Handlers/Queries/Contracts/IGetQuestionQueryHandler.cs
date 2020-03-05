using Quizard.Core.Handlers.Queries.Contracts.Base;
using Quizard.Core.Models.Domain;
using Quizard.Core.Models.Query;

namespace Quizard.Core.Handlers.Queries.Contracts
{
    public interface IGetQuestionQueryHandler:IQueryHandler<GetQuestionQuery, Question>
    {
    }
}
