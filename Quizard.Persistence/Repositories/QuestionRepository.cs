using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quizard.Core.Models.Domain;
using Quizard.Core.Models.Dto;
using Quizard.Core.Repositories;

namespace Quizard.Persistence.Repositories
{
    public class QuestionRepository:IQuestionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public QuestionRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Question> AddQuestion(Question question)
        {
            var entity = _mapper.Map<Models.Question>(question);
            _context.Questions.Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<Question>(entity);
        }

        public async Task<PagedResult<Question>> GetAll(int pageNumber, int pageSize)
        {
            var query = _context.Questions.Include(x => x.Answers);
            var count = await query.CountAsync();
            var entities = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            var data = _mapper.Map<List<Question>>(entities);
            return new PagedResult<Question>
            {
                Data = data,
                Meta = new PagedResultMeta
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    Total = count
                }
            };
        }

        public async Task<Question> GetById(Guid id)
        {
            var entity = await _context.Questions.Include(x => x.Answers).FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<Question>(entity);
        }
    }
}
