using TextGenerator.Models;
using TextGenerator.Web.Api.Interfaces;

namespace TextGenerator.Web.Api.Requests
{
    public class TextGenerationRequest : ITextGenerationRequest
    {
        public string Template { get; set; }
        public DataModel DataModel { get; set; }
    }
}
