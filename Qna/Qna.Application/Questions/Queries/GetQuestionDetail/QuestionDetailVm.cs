using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Qna.Application.Interfaces.Mappings;
using Qna.Domain.Models;

namespace Qna.Application.Questions.Queries.GetQuestionDetail
{
    public class QuestionDetailVm : IMapFrom<Question>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string QuestionText { get; set; }
        public int AuthorId { get; set; }
        public string AuthorDisplayName { get; set; }
        public string AuthorEmailAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<QuestionAnswerDetailsVm> Answers { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Question, QuestionDetailVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.QuestionId))
                .ForMember(d => d.AuthorDisplayName, opt => opt.MapFrom(s => s.Author.DisplayName))
                .ForMember(d => d.AuthorEmailAddress, opt => opt.MapFrom(s => s.Author.EmailAddress));

        }
    }
}
