using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Qna.Application.Interfaces;

namespace Qna.Application.Questions.Queries.GetQuestionsList
{
    public class GetQuestionsListQuery : IRequest<List<QuestionListVm>>
    {
        public class Handler : IRequestHandler<GetQuestionsListQuery, List<QuestionListVm>>
        {
            private readonly IDatabaseContext _context;
            private readonly IMapper _mapper;

            public Handler(IDatabaseContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<QuestionListVm>> Handle(GetQuestionsListQuery req, CancellationToken ct)
            {
                var questions = await _context.Questions.Include(q => q.Author)
                    .ProjectTo<QuestionListVm>(_mapper.ConfigurationProvider)
                    .ToListAsync(ct);

                if (questions == null)
                {
                    throw new Exception("No questions were found"); // TODO: Replace with custom exception.
                }

                // TODO: Add ability to paginate with page + offset.

                return questions;

            }
        }
    }
}
