using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Qna.Application.Interfaces;
using Qna.Application.UnitTests.Common;
using Xunit;

namespace Qna.Application.UnitTests.Questions.Queries.GetQuestionDetail
{
    public class GetQuestionDetailQueryTests : IDisposable
    {
        public IDatabaseContext _context;
        public IMapper _mapper;

        public GetQuestionDetailQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GivenValidRequest_ShouldGetQuestion()
        {
            // Arrange //
            var handler = new GetQuestionDetail.Handler(_context, _mapper);

            // Act //
            var result = await handler.Handle(new GetQuestionDetail(1), CancellationToken.None);

            // Assert //
            result.ShouldBeOfType<QuestionDetailVm>();
            result.Title.ShouldBe("Please help!");
            result.Id.ShouldBe(1);


        }
    }
}
