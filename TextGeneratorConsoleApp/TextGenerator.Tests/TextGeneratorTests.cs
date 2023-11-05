using TextGenerator.Api;
using TextGenerator.Models;

namespace TextGenerator.Tests;

[TestClass]
public class TextGeneratorTests
{
    [TestMethod]
    public void GenerateText_WithValidTemplateAndDataModel_ReplacesPlaceholders()
    {
        // Arrange
        var generator = new TextGeneration();
        var template = "Hello {Name}, welcome to {Location}!";
        var dataModel = new { Name = "John", Location = "New York" };

        // Act
        string result = generator.GenerateText(template, dataModel);

        // Assert
        Assert.AreEqual("Hello John, welcome to New York!", result);
    }

    [TestMethod]
    public void GenerateText_WithNullDataModel_ThrowsArgumentNullException()
    {
        // Arrange
        var generator = new TextGeneration();
        string template = "Hello {Name}, welcome to {Location}!";
        object dataModel = null;

        // Act and Assert
        Assert.ThrowsException<ArgumentNullException>(() => generator.GenerateText(template, dataModel));
    }
    
    [TestMethod]
    public void GenerateText_WithNullTemplate_ThrowsArgumentNullException()
    {
        // Arrange
        var generator = new TextGeneration();
        string template = null;
        var dataModel = new { Name = "John", Location = "New York" };

        // Act and Assert
        Assert.ThrowsException<ArgumentNullException>(() => generator.GenerateText(template, dataModel));
    }

    [TestMethod]
    public void GenerateText_ForDataModel1()
    {
        // Arrange
        var generator = new TextGeneration();

        // Act
        string result = generator.GenerateText(Constants.template1, Constants.dataModel1);

        // Assert
        Assert.AreEqual("Hello John Doe,\n\nWe will be glad to see you in our office in Budapest at Main Street, 1.\n\nLooking forward to meeting with you!\n\n\nBest, Our company.", result);
    }

    [TestMethod]
    public void GenerateText_ForDataModel2()
    {
        // Arrange
        var generator = new TextGeneration();

        // Act
        string result = generator.GenerateText(Constants.template2, Constants.dataModel2);

        // Assert
        Assert.AreEqual("Welcome Alex Peter to Nix Technologies, We are writing you this email to confirm your selection in our Software Developers department and section will be .Net Developers.\nYou will be joining other 5 members.\nYour vast experience of 8 years will help us moving forward.\nHere is your Employee Id: 123xyz.\n\nRegards.\nNix Technologies HR.", result);
    }
}
