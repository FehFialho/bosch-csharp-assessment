namespace InkFlow.Services.TextValidation;

public class TextValidationService : ITextValidationService
{
    private const int MaxLines = 100;
    private const int MaxWords = 1000;
    private const int MaxChars = 6000;

    public Task<bool> Validate(string text)
    {
        if (string.IsNullOrEmpty(text))
            return Task.FromResult(false);

        // Verificar caracteres
        if (text.Length > MaxChars)
            return Task.FromResult(false);

        // Verificar linhas
        var lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        if (lines.Length > MaxLines)
            return Task.FromResult(false);

        // Verificar palavras
        var wordCount = text.Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
        if (wordCount > MaxWords)
            return Task.FromResult(false);

        return Task.FromResult(true);
    }
}
