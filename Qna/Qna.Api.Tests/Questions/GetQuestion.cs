using Newtonsoft.Json;
using Qna.Api.Shared;
using Qna.Api.Tests.Common;
using Qna.Application.Questions.Queries.GetQuestionDetail;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Qna.Api.Tests.Questions
{
    public class GetQuestion : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public GetQuestion(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Returns_ApiResponse_WithCorrectQuestion()
        {
            // Arrange //
            var client = await _factory.GetHttpClient();

            // Act //
            var response = await client.GetAsync("/api/questions/get/1");
            response.EnsureSuccessStatusCode();
            var responseObject = await Utilities.GetResponseContent<ApiResponse>(response);
            var viewModel = JsonConvert.DeserializeObject<QuestionDetailVm>(responseObject.Data.ToString());

            // Assert //
            responseObject.Success.ShouldBe(true);
            responseObject.DataCount.ShouldBe(1);
            viewModel.Title.ShouldBe("Please help!");
        }
    }
}