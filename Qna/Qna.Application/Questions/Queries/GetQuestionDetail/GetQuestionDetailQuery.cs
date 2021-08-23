using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Qna.Application.Questions.Queries.GetQuestionDetail
{
    public class GetQuestionDetailQuery : IRequest<QuestionDetailVm>
    {
        public string Id { get; set; }

        public GetQuestionDetailQuery(string id)
        {
            Id = id;
        }


    }
}
