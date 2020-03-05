using Microsoft.AspNetCore.Mvc;
using Quizard.Core.Handlers.Command;
using Quizard.Core.Handlers.Queries.Contracts;
using Quizard.Core.Models.Command;
using Quizard.Core.Models.Query;
using System;
using System.Threading.Tasks;

namespace Quizard.API.Controllers
{
    [Route("api/questions")]
    [ApiController]
    public class QuestionController:ControllerBase
    {
        private readonly IAddQuestionCommandHandler _addQuestionCommandHandler;
        private readonly IGetAllQuestionsQueryHandler _getAllQuestionsQueryHandler;
        private readonly IGetQuestionQueryHandler _getQuestionQueryHandler;

        public QuestionController(IAddQuestionCommandHandler addQuestionCommandHandler, IGetAllQuestionsQueryHandler getAllQuestionsQueryHandler, IGetQuestionQueryHandler getQuestionQueryHandler)
        {
            _addQuestionCommandHandler = addQuestionCommandHandler;
            _getAllQuestionsQueryHandler = getAllQuestionsQueryHandler;
            _getQuestionQueryHandler = getQuestionQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int? pageNumber, int? pageSize)
        {
            var query = new GetAllQuestionsQuery
            {
                PageNumber = pageNumber ?? 1,
                PageSize = pageSize ?? 10
            };
            return Ok(await _getAllQuestionsQueryHandler.Handle(query));
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetQuestionQuery
            {
                Id = id
            };
            var result = await _getQuestionQueryHandler.Handle(query);
            
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddQuestionCommand command)
        {
            var result = await _addQuestionCommandHandler.AddQuestion(command);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

    }
}
