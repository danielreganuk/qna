using AutoMapper;
using Qna.Application.Interfaces.Mappings;
using Qna.Domain.Models;
using System;

namespace Qna.Application.Questions.Queries.GetQuestionDetail
{
    public class QuestionAnswerDetailsVm : IMapFrom<Answer>
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public int AuthorId { get; set; }
        public string AuthorDisplayName { get; set; }
        public string AuthorEmailAddress { get; set; }
        public DateTime CreatedDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Answer, QuestionAnswerDetailsVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.AnswerId))
                .ForMember(d => d.AuthorDisplayName, opt => opt.MapFrom(s => s.Author.DisplayName))
                .ForMember(d => d.AuthorEmailAddress, opt => opt.MapFrom(s => s.Author.EmailAddress));
        }
    }
}