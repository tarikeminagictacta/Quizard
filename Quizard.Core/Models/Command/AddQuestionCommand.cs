using System.Collections.Generic;

namespace Quizard.Core.Models.Command
{
    public class AddQuestionCommand
    {
        public string Text { get; set; }
        public IEnumerable<AnswerDto> Answers { get; set; }
    }

    public class AnswerDto
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}
