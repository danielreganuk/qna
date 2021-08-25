using MediatR;
using Qna.Application.Interfaces;
using Qna.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qna.Application.Answers.Commands.CreateAnswer
{
    public class CreateAnswerCommand : IRequest<int>
    {
        public int QuestionId { get; private set; }
        public string AnswerText { get; private set; }
        public Author Author { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public int? AuthorId { get; set; }

        public CreateAnswerCommand(int questionId, string answerText, Author author, DateTime createdDate, int? authorId = null)
        {
            QuestionId = questionId;
            AnswerText = answerText;
            Author = author;
            CreatedDate = createdDate;
            AuthorId = authorId;
        }

        public class Handler : IRequestHandler<CreateAnswerCommand, int>
        {
            private readonly IDatabaseContext _context;
            private readonly IMediator _mediator;

            public Handler(IDatabaseContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<int> Handle(CreateAnswerCommand req, CancellationToken ct)
            {
                var entity = new Answer
                {
                    AnswerText = req.AnswerText,
                    QuestionId = req.QuestionId,
                    CreatedDate = req.CreatedDate
                };

                if (!req.AuthorId.HasValue)
                {
                    entity.Author = req.Author;
                }
                else
                {
                    entity.AuthorId = req.AuthorId.Value;
                }

                await _context.Answers.AddAsync(entity, ct);
                await _context.SaveChangesAsync(ct);

                return entity.AnswerId;
            }
        }
    }
}