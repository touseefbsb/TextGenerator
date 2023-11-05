namespace TextGenerator.Interfaces
{
    public interface ITextGeneration
    {
        string GenerateText(string template, object dataModel);
    }
}