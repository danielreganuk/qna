using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Qna.Application.Interfaces;
using Qna.Domain.Models;

namespace Qna.Application.Authors.Queries.GetAuthorByEmailAddress
{
    public class GetAuthorByEmailAddressQuery : IRequest<Author>
    {
        public string EmailAddress { get; private set; }

        public GetAuthorByEmailAddressQuery(string emailAddress)
        {
            EmailAddress = emailAddress;
        }

        public class Handler : IRequestHandler<GetAuthorByEmailAddressQuery, Author>
        {
            private readonly IDatabaseContext _context;

            public Handler(IDatabaseContext context)
            {
                _context = context;
            }


            public async Task<Author> Handle(GetAuthorByEmailAddressQuery req, CancellationToken ct)
            {
                var entity =
                    await _context.Authors.FirstOrDefaultAsync(
                        a => a.EmailAddress.ToUpper() == req.EmailAddress.ToUpper(), ct);

                if (entity == null)
                {
                    throw new Exception("Author cannot be found"); // TODO: Replace with custom exception.
                }

                return entity;
            }
        }
    }
}
