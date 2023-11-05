namespace TextGenerator.Client.Swag
{
    public class TextGeneratorBaseClient
    {
        protected virtual async Task<HttpClient> CreateHttpClientAsync(CancellationToken cancellationToken = default)
        {
            await Task.Delay(1);
            HttpClient result = new()
            {
                BaseAddress = new System.Uri("https://localhost:7220/")
            };
            return result;
        }
    }
}
