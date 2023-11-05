using Microsoft.AspNetCore.Mvc;
using TextGenerator.Interfaces;
using TextGenerator.Web.Api.Interfaces;
using TextGenerator.Web.Api.Requests;
using TextGenerator.Web.Api.Responses;

namespace TextGenerator.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TextGeneratorController : ControllerBase
    {
        private readonly ITextGeneration _textGeneration;

        public TextGeneratorController(ITextGeneration textGeneration) => _textGeneration = textGeneration;

        [HttpGet]
        [Route(nameof(GenerateText))]
        public ActionResult<TextGenerationResponse> GenerateText([FromBody] TextGenerationRequest request) => GetGeneratedText(request);

        [HttpGet]
        [Route(nameof(GenerateText2))]
        public ActionResult<TextGenerationResponse> GenerateText2([FromBody] TextGenerationRequest2 request) => GetGeneratedText(request);

        private ActionResult<TextGenerationResponse> GetGeneratedText(ITextGenerationRequest request)
        {
            string generatedText = null;
            if (request is TextGenerationRequest textGenerationRequest)
            {
                generatedText = _textGeneration.GenerateText(textGenerationRequest.Template, textGenerationRequest.DataModel);
            }
            else if (request is TextGenerationRequest2 textGenerationRequest2)
            {
                generatedText = _textGeneration.GenerateText(textGenerationRequest2.Template, textGenerationRequest2.DataModel);

            }
            var result = generatedText.Replace("\\n", "\n");
            return Ok(new TextGenerationResponse { Result = result });
        }
    }
}