using FluentAssertions;
using Quizard.Core.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Quizard.Core.Tests
{
    public class CreateQuestionShould
    {
        [Fact]
        public void NotAllowToCreateQuestionIfQuestionTextNotProvided()
        {
            var exception = Assert.Throws<ArgumentException>(() => new Question(null, null));
            exception.ParamName.Should().Be(nameof(Question.Text));
        }

        [Fact]
        public void NotAllowToCreateQuestionIfQuestionTextIsEmpty()
        {
            var exception = Assert.Throws<ArgumentException>(() => new Question(string.Empty, null));
            exception.ParamName.Should().Be(nameof(Question.Text));
        }

        [Fact]
        public void NotAllowToCreateQuestionIfQuestionTextIsWhitespace()
        {
            var exception = Assert.Throws<ArgumentException>(() => new Question("       ", null));
            exception.ParamName.Should().Be(nameof(Question.Text));
        }

        [Fact]
        public void NotAllowToCreateQuestionIfNoAnswersIsProvided()
        {
            var exception1 = Assert.Throws<ArgumentException>(() => new Question("What is older, chicken or egg?", null));
            var exception2 = Assert.Throws<ArgumentException>(() => new Question("What is older, chicken or egg?", new List<Answer>()));
            exception1.ParamName.Should().Be(nameof(Question.Answers));
            exception2.ParamName.Should().Be(nameof(Question.Answers));
        }

        [Fact]
        public void NotAllowToCreateQuestionBelowTwoAnswer()
        {
            var answers = new List<Answer> { new Answer("Chicken", true) };

            var exception = Assert.Throws<ArgumentException>(() => new Question("What is older, chicken or egg?", answers));

            exception.ParamName.Should().Be(nameof(Question.Answers));

        }

        [Fact]
        public void NotAllowToCreateQuestionIfNoAnswersIsCorrect()
        {
            var answers = new List<Answer> { new Answer("Chicken", false), new Answer("Egg", false) };

            var exception = Assert.Throws<ArgumentException>(() => new Question("What is older, chicken or egg?", answers));

            exception.ParamName.Should().Be(nameof(Question.Answers));

        }

        [Fact]
        public void NotAllowToCreateQuestionIfMoreThanOneAnswerIsCorrect()
        {
            var answers = new List<Answer> { new Answer("Chicken", true), new Answer("Egg", true) };

            var exception = Assert.Throws<ArgumentException>(() => new Question("What is older, chicken or egg?", answers));

            exception.ParamName.Should().Be(nameof(Question.Answers));

        }

        [Fact]
        public void CreateQuestionIfTextIsProvidedAndHaveOneCorrectAnswer()
        {
            var answers = new List<Answer> { new Answer("Chicken", false), new Answer("Egg", true) };

            var question = new Question("What is older, chicken or egg?", answers);

            question.Should().NotBeNull();
        }

        [Fact]
        public void SetParametersToCorrectValues()
        {
            var questionText = "What is older, chicken or egg?";
            var answers = new List<Answer> { new Answer("Chicken", false), new Answer("Egg", true) };

            var question = new Question(questionText, answers);

            question.Text.Should().Be(questionText);
            question.Answers.Should().BeEquivalentTo(answers);
            question.Id.Should().NotBeEmpty();
            question.Answers.Any(x => x.Id == Guid.Empty).Should().BeFalse();
            question.Answers.Any(x => string.IsNullOrWhiteSpace(x.Text)).Should().BeFalse();
        }
    }
}
