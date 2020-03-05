using System;

namespace Quizard.Core.Models.Domain
{
    public class Answer
    {
        public Guid Id { get; private set; }
        public string Text { get; private set; }
        public bool IsCorrect { get; private set; }

        public Answer(string text, bool isCorrect)
        {
            if( string.IsNullOrWhiteSpace(text) )
            {
                throw new ArgumentException("Answer text cannot be empty", nameof(Text));
            }

            Text = text;
            IsCorrect = isCorrect;
            Id = Guid.NewGuid();
        }
    }
}