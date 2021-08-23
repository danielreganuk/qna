using AutoMapper;
using Qna.Application.Interfaces.Mappings;
using Qna.Domain.Models;
using System;

namespace Qna.Application.Questions.Queries.GetQuestionsList
{
    public class QuestionListVm : IMapFrom<Question>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string QuestionText { get; set; }
        public int AuthorId { get; set; }
        public string AuthorDisplayName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int AnswerCount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Question, QuestionListVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.QuestionId))
                .ForMember(d => d.AuthorDisplayName, opt => opt.MapFrom(s => s.Author.DisplayName))
                .ForMember(d => d.AnswerCount, opt => opt.MapFrom(s => s.Answers.Count));
        }
    }
}