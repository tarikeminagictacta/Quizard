using FluentAssertions;
using Quizard.Core.Models.Domain;
using System;
using Xunit;

namespace Quizard.Core.Tests
{
    public class CreateAnswerShould
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("     ")]
        public void NotAllowCreationOfEmptyText(string answerText)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Answer(answerText, true));
            exception.ParamName.Should().Be(nameof(Answer.Text));
        }
    }
}
