namespace InkFlow.Services.TextValidation;
public interface ITextValidationService
{
    Task<Boolean> Validate(string text);
}