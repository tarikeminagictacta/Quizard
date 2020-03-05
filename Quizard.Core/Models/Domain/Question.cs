using System;
using System.Collections.Generic;
using System.Linq;

namespace Quizard.Core.Models.Domain
{
    public class Question
    {
        public Guid Id { get; private set; }
        public string Text { get; private set; }
        public ICollection<Answer> Answers { get; private set; }

        private Question()
        {
            
        }

        public Question(string text, ICollection<Answer> answers)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException("Question text cannot be empty", nameof(Text));
            }

            if (answers == null)
            {
                throw new ArgumentException("You cannot create question without answers", nameof(Answers));
            }

            if (answers.Count < 2)
            {
                throw new ArgumentException("You need at least two answers for question");
            }

            if (answers.Count(x => x.IsCorrect) != 1)
            {
                throw new ArgumentException("Only one answer should be correct");
            }


            Id = Guid.NewGuid();
            Text = text;
            Answers = answers;
        }
    }
}
