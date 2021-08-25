using Qna.Api.Shared;
using Qna.Api.Tests.Common;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Qna.Api.Tests.Questions
{
    public class GetQuestionsList : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public GetQuestionsList(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Returns_ApiResponse_WithSuccessStatus()
        {
            // Arrange //
            var client = await _factory.GetHttpClient();

            // Act //
            var response = await client.GetAsync("/api/questions/getall");
            response.EnsureSuccessStatusCode();
            var responseObject = await Utilities.GetResponseContent<ApiResponse>(response);

            // Assert //
            responseObject.Success.ShouldBe(true);
            responseObject.DataCount.ShouldBe(3);
        }
    }
}