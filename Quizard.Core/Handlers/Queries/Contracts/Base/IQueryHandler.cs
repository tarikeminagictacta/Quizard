using System.Threading.Tasks;

namespace Quizard.Core.Handlers.Queries.Contracts.Base
{
    public interface IQueryHandler<in TInput, TOutput>
    {
        Task<TOutput> Handle(TInput query);
    }
}
