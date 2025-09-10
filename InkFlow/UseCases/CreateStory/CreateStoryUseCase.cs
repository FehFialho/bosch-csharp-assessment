using InkFlow;
using InkFlow.Entities;
using InkFlow.Services.TextValidation;
using InkFlow.UseCases.CreateStory;

public class CreateStoryUseCase
{
    private readonly InkFlowDbContext _ctx;
    private readonly ITextValidationService _validationService;

    public CreateStoryUseCase(
        InkFlowDbContext ctx,
        ITextValidationService validationService
    )
    {
        _ctx = ctx;
        _validationService = validationService;
    }

    public async Task<Result<CreateStoryResponse>> Do(CreateStoryPayload payload)
    {
        var writer = await _ctx.users.FindAsync(payload.WriterID);

        if (writer is null)
            return Result<CreateStoryResponse>.Fail("Usuário não encontrado");

        var isValid = await _validationService.Validate(payload.Text);

        if (!isValid)
            return Result<CreateStoryResponse>.Fail("O texto não atende os critérios!");

        var story = new Story
        {
            Title = payload.Title,
            Text = payload.Text,
            Writer = writer
        };

        _ctx.stories.Add(story);
        await _ctx.SaveChangesAsync();
        return Result<CreateStoryResponse>.Success(new());
    }
}
