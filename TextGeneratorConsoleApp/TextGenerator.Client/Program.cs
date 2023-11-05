using TextGenerator.Api;
using TextGenerator.Models;

var inputs = new Dictionary<string, object>
{
    { Constants.template1, Constants.dataModel1 },
    { Constants.template2, Constants.dataModel2 }
};

TextGeneration generator = new();

int i = 1;

foreach (var input in inputs)
{
    Console.WriteLine($"Template{i} and DataModel{i} output :\n");

    string result = generator.GenerateText(input.Key, input.Value);

    Console.WriteLine(result + "\n");

    i++;
}
