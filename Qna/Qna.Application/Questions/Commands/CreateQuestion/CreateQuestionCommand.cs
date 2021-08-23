using MediatR;
using Qna.Application.Interfaces;
using Qna.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qna.Application.Questions.Commands.CreateQuestion
{
    public class CreateQuestionCommand : IRequest<Question>
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public Author Author { get; set; }
        public DateTime CreatedDate { get; set; }

        public CreateQuestionCommand(string title, string text, Author author, DateTime createdDate)
        {
            Title = title;
            Text = text;
            Author = author;
            CreatedDate = createdDate;
        }

        public class Handler : IRequestHandler<CreateQuestionCommand, Question>
        {
            private readonly IDatabaseContext _context;
            private readonly IMediator _mediator;

            public Handler(IDatabaseContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Question> Handle(CreateQuestionCommand req, CancellationToken ct)
            {
                var entity = new Question
                {
                    Title = req.Title,
                    QuestionText = req.Text,
                    CreatedDate = req.CreatedDate,
                    Author = req.Author
                };

                await _context.Questions.AddAsync(entity, ct);
                await _context.SaveChangesAsync(ct);

                return entity;
            }
        }
    }
}