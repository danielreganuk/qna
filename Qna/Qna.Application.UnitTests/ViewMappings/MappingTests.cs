using AutoMapper;
using Qna.Application.Questions.Queries.GetQuestionDetail;
using Qna.Application.Questions.Queries.GetQuestionsList;
using Qna.Domain.Models;
using Shouldly;
using Xunit;

namespace Qna.Application.UnitTests.ViewMappings
{
    public class MappingTests : IClassFixture<MappingTestsFixture>
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests(MappingTestsFixture fixture)
        {
            _configuration = fixture.ConfigurationProvider;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void ShouldMapQuestionToQuestionDetailVm()
        {
            var entity = new Question();

            var result = _mapper.Map<QuestionDetailVm>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<QuestionDetailVm>();
        }

        [Fact]
        public void ShouldMapQuestionToQuestionListVm()
        {
            var entity = new Question();

            var result = _mapper.Map<QuestionListVm>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<QuestionListVm>();
        }
    }
}