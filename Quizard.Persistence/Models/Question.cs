using System;
using System.Collections.Generic;

namespace Quizard.Persistence.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
