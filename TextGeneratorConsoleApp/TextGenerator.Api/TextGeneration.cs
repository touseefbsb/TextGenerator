using System.Text.RegularExpressions;
using TextGenerator.Interfaces;

namespace TextGenerator.Api;

public class TextGeneration : ITextGeneration
{
    /// <summary>
    /// Generates text by replacing placeholders in the template with values from the data model.
    /// Please make sure that each template has a unique data model type for it and vice versa.
    /// </summary>
    /// <param name="template">The template containing placeholders.</param>
    /// <param name="dataModel">The data model containing property values.</param>
    /// <returns>The generated text with placeholders replaced by values.</returns>
    public string GenerateText(string template, object dataModel)
    {
        if (template is null || dataModel is null)
            throw new ArgumentNullException("Template and data model cannot be null.");

        string result = template;

        // Use regular expressions to find placeholders in the template.
        // Escaping the { and } to use as literl string part.
        // using () paranthesis for defining a capturing group.
        // group consists of 1 or more characters that are not closing curly brace }
        var placeholders = Regex.Matches(template, @"\{([^}]+)\}");

        foreach (Match placeholder in placeholders)
        {
            // Get the property name from the placeholder.
            string propertyName = placeholder.Groups[1].Value;

            // Use reflection to get the value of the property from the data model.
            var propertyValue = GetNestedPropertyValue(dataModel, propertyName);

            // Replace the placeholder with the property value.
            result = result.Replace(placeholder.Value, propertyValue?.ToString() ?? string.Empty);
        }
        return result;
    }

    /// <summary>
    /// Gets the value of a nested property from the data model.
    /// </summary>
    private object GetNestedPropertyValue(object obj, string propertyName)
    {
        // Splits the property name so we can use each part of it.
        foreach (string part in propertyName.Split('.'))
        {
            // if the nested object like Address is null.
            if (obj is null)
                return null;

            var type = obj.GetType();

            var property = type.GetProperty(part);

            // also here if property doesnt exist on the object with that "part" name.
            if (property is null)
                return null;

            // get actual value of the property to put in the template.
            obj = property.GetValue(obj, null);
        }
        return obj;
    }
}
