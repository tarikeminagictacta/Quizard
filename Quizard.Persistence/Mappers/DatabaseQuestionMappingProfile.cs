using AutoMapper;
using Quizard.Core.Models.Domain;

namespace Quizard.Persistence.Mappers
{
    public class DatabaseQuestionMappingProfile:Profile
    {
        public DatabaseQuestionMappingProfile()
        {
            CreateMap<Question, Models.Question>().ReverseMap();
            CreateMap<Answer, Models.Answer>().ReverseMap();
        }
    }
}
