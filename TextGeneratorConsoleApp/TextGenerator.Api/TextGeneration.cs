using System.Text.RegularExpressions;
using TextGenerator.Interfaces;

namespace TextGenerator.Api;

public class TextGeneration : ITextGeneration
{
    /// <summary>
    /// Generates text by replacing placeholders in the template with values from the data model. Using regex method.
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
    /// Generates text by replacing placeholders in the template with values from the data model. Using Split method.
    /// Please make sure that each template has a unique data model type for it and vice versa.
    /// </summary>
    /// <param name="template">The template containing placeholders.</param>
    /// <param name="dataModel">The data model containing property values.</param>
    /// <returns>The generated text with placeholders replaced by values.</returns>
    public string GenerateText2(string template, object dataModel)
    {
        // Check for null inputs
        if (template is null || dataModel is null)
            throw new ArgumentNullException("Template and data model cannot be null.");

        // Initialize result with the template
        string result = template;

        // Define delimiters for splitting
        char[] delimiters = { '{', '}' };

        // Split the template into parts using delimiters
        string[] parts = template.Split(delimiters);

        // Iterate over odd indices to process placeholder parts
        for (int i = 1; i < parts.Length; i += 2)
        {
            // Extract placeholder from parts
            string propertyName = parts[i];

            // Get the nested property value
            var propertyValue = GetNestedPropertyValue(dataModel, propertyName);

            // Replace the placeholder with the property value in the result
            result = result.Replace("{" + propertyName + "}", propertyValue?.ToString() ?? string.Empty);
        }

        // Return the generated text
        return result;
    }

    /// <summary>
    /// Generates text by replacing placeholders in the template with values from the data model. Using custom parameter format method.
    /// Please make sure that each template has a unique data model type for it and vice versa.
    /// </summary>
    /// <param name="template">The template containing placeholders.</param>
    /// <param name="dataModel">The data model containing property values.</param>
    /// <returns>The generated text with placeholders replaced by values.</returns>
    public string GenerateText3(string template, object dataModel)
    {
        // Check for null inputs
        if (template is null || dataModel is null)
            throw new ArgumentNullException("Template and data model cannot be null.");

        // Initialize result with the template
        string result = template;

        // Process placeholders until none are left in the result
        while (result.Contains("{") && result.Contains("}"))
        {
            // Find the indices of the first occurrence of '{' and '}'
            int startIndex = result.IndexOf("{");
            int endIndex = result.IndexOf("}");

            // Check for valid placeholder indices
            if (startIndex != -1 && endIndex != -1 && endIndex > startIndex)
            {
                // Extract placeholder from result
                string placeholder = result.Substring(startIndex + 1, endIndex - startIndex - 1);

                // Get the nested property value
                var propertyValue = GetNestedPropertyValue(dataModel, placeholder);

                // Replace the placeholder with the property value in the result
                result = result.Replace("{" + placeholder + "}", propertyValue?.ToString() ?? string.Empty);
            }
            else
            {
                // Break the loop if a malformed placeholder is found
                break;
            }
        }

        // Return the generated text
        return result;
    }

    #region HelpingMethods
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
    #endregion HelpingMethods
}
