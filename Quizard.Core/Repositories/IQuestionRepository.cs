using System;
using Quizard.Core.Models.Domain;
using Quizard.Core.Models.Dto;
using System.Threading.Tasks;

namespace Quizard.Core.Repositories
{
    public interface IQuestionRepository
    {
        Task<Question> AddQuestion(Question question);
        Task<PagedResult<Question>> GetAll(int pageNumber, int pageSize);
        Task<Question> GetById(Guid id);
    }
}
