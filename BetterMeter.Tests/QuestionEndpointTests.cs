namespace BetterMeter.Tests
{
    // Here we demonstrate how to write integration tests for our API
    // Read more about integration tests here:
    // https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-9.0
    //
    // ******************************************************************************************
    public class QuestionEndpointTests : IClassFixture<BetterMeterWebApplicationFactory<Program>>
    {
        private readonly BetterMeterWebApplicationFactory<Program> _factory;

        public QuestionEndpointTests(BetterMeterWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/questions")]
        [InlineData("/api/questions/1")]
        [InlineData("/api/quiz")]
        [InlineData("/api/quiz/1")]
        public async Task EndpointsReturnStuff(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act - Simulate a GET request to the url
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            // Assert - Check if the response is as expected
            response.EnsureSuccessStatusCode(); // Status Code 200-299

            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());

            Assert.NotEmpty(await response.Content.ReadAsStringAsync());
        }

        [Fact]
        public async Task GetQuestionGetsCorrectQuestion()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act - Simulate a GET request to the url
            var response = await client.GetAsync("/api/questions/1");
            var content = await response.Content.ReadAsStringAsync();
            
            // Assert - Check if the response is as expected
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
            Assert.Contains("What is the capital of Sweden?", content);
            Assert.Contains("Stockholm", content);
            Assert.Contains("Berlin", content);
            Assert.Contains("Oslo", content);
            Assert.Contains("Madrid", content);
        }

        // TODO: What else can we test?
    }
}
