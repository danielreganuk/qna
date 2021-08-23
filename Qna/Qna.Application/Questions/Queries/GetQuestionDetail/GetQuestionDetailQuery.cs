using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Qna.Application.Interfaces;
using Qna.Application.Questions.Commands.CreateQuestion;
using Qna.Domain.Models;

namespace Qna.Application.Questions.Queries.GetQuestionDetail
{
    public class GetQuestionDetailQuery : IRequest<QuestionDetailVm>
    {
        public int Id { get; set; }

        public GetQuestionDetailQuery(int id)
        {
            Id = id;
        }

        public class Handler : IRequestHandler<GetQuestionDetailQuery, QuestionDetailVm>
        {
            private readonly IDatabaseContext _context;
            private readonly IMapper _mapper;

            public Handler(IDatabaseContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<QuestionDetailVm> Handle(GetQuestionDetailQuery req, CancellationToken ct)
            {
                var entity = await _context.Questions.Include(q => q.Author).Include(q => q.Answers)
                    .ThenInclude(a => a.Author).FirstOrDefaultAsync(q => q.QuestionId == req.Id, ct);

                if (entity == null)
                {
                    throw new Exception("Question cannot be found"); // TODO: Replace with custom exception.
                }

                return _mapper.Map<QuestionDetailVm>(entity);
            }
        }
    }
}
