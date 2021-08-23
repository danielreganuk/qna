using System;
using System.Collections.Generic;
using AutoMapper;
using Qna.Application.Interfaces;
using Qna.Application.Questions.Queries.GetQuestionDetail;
using Qna.Application.UnitTests.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Qna.Application.Questions.Queries.GetQuestionsList;
using Xunit;

namespace Qna.Application.UnitTests.Questions.Queries.GetQuestionsList
{
    [Collection("QueryCollection")]
    public class GetQuestionsListQueryTests
    {
        public IDatabaseContext _context;
        public IMapper _mapper;

        public GetQuestionsListQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task ShouldGetQuestionsList()
        {
            // Arrange //
            var handler = new GetQuestionsListQuery.Handler(_context, _mapper);

            // Act //
            var result = await handler.Handle(new GetQuestionsListQuery(), CancellationToken.None);

            // Assert //
            result.ShouldBeOfType<List<QuestionListVm>>();
            result.Count.ShouldBe(3);
        }

    }
}