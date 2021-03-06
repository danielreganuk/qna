using AutoMapper;
using Qna.Application.Authors.Queries.GetAuthorByEmailAddress;
using Qna.Application.Interfaces;
using Qna.Application.UnitTests.Common;
using Qna.Domain.Models;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
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
            var handler = new GetAuthorByEmailAddressQuery.Handler(_context);

            // Act //
            var result = await handler.Handle(new GetAuthorByEmailAddressQuery("qm1@moq.com"), CancellationToken.None);

            // Assert //
            result.ShouldBeOfType<Author>();
            result.AuthorId.ShouldBe(1);
        }

        [Fact]
        public async Task GivenInvalidAuthorEmail_ShouldThrowException()
        {
            // Arrange //
            var handler = new GetAuthorByEmailAddressQuery.Handler(_context);

            // Act //
            var result = await Should.ThrowAsync<Exception>(async () => await handler.Handle(new GetAuthorByEmailAddressQuery("qm01@moq.com"), CancellationToken.None));

            // Assert //
            result.ShouldBeOfType<Exception>();
        }
    }
}