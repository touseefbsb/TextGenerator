using TextGenerator.Models;
using TextGenerator.Web.Api.Interfaces;

namespace TextGenerator.Web.Api.Requests
{
    public class TextGenerationRequest2 : ITextGenerationRequest
    {
        public string Template { get; set; }
        public DataModel2 DataModel { get; set; }
    }
}
