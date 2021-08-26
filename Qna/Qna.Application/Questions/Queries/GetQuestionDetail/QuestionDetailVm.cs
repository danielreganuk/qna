using AutoMapper;
using Qna.Application.Interfaces.Mappings;
using Qna.Domain.Models;
using System;
using System.Collections.Generic;

namespace Qna.Application.Questions.Queries.GetQuestionDetail
{
    public class QuestionDetailVm : IHaveCustomMapping
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string QuestionText { get; set; }
        public int AuthorId { get; set; }
        public string AuthorDisplayName { get; set; }
        public string AuthorEmailAddress { get; set; }
        public string CreatedDate { get; set; }
        public List<QuestionAnswerDetailsVm> Answers { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Question, QuestionDetailVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.QuestionId))
                .ForMember(d => d.AuthorDisplayName, opt => opt.MapFrom(s => s.Author.DisplayName))
                .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate.ToString("hh:mm dd-MM-yyyy")))
                .ForMember(d => d.AuthorEmailAddress, opt => opt.MapFrom(s => s.Author.EmailAddress));
        }
    }
}