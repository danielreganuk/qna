using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Qna.Application.Interfaces;
using Qna.Application.Questions.Queries.GetQuestionDetail;
using Qna.Application.UnitTests.Common;
using Qna.Domain.Models;
using Shouldly;
using Xunit;

namespace Qna.Application.UnitTests.Authors.Queries.GetAuthorByEmailAddress
{
    [Collection("QueryCollection")]
    public class GetAuthorByEmailAddressQueryTests
    {
        public IDatabaseContext _context;
        public IMapper _mapper;

        public GetAuthorByEmailAddressQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GivenAuthorEmail_ShouldGetAuthor()
        {
            // Arrange //
            var handler = new GetAuthorByEmailAddress.Handler(_context, _mapper);

            // Act //
            var result = await handler.Handle(new GetAuthorByEmailAddress("qm1@moq.com"), CancellationToken.None);

            // Assert //
            result.ShouldBeOfType<Author>();
            result.AuthorId.ShouldBe(1);
        }

        [Fact]
        public async Task GivenInvalidAuthorEmail_ShouldThrowException()
        {
            // Arrange //
            var handler = new GetAuthorByEmailAddress.Handler(_context, _mapper);

            // Act //
            var result = await Should.ThrowAsync<Exception>(async () => await handler.Handle(new GetAuthorByEmailAddress("qm01@moq.com"), CancellationToken.None));

            // Assert //
            result.ShouldBeOfType<Exception>();
        }
    }
}
