using InkFlow;
using InkFlow.Entities;
using InkFlow.Services.TextValidation;
using InkFlow.UseCases.CreateStory;
using Microsoft.IdentityModel.Tokens;

public class CreateStoryUseCase(
        InkFlowDbContext ctx,
        TextValidationService validationService
    )
{
    public async Task<Result<CreateStoryResponse>> Do(CreateStoryPayload payload)
    {
        var writer = await ctx.users.FindAsync(payload.WriterID);

        if (writer is null)
            return Result<CreateStoryResponse>.Fail("Usuário não encontrado");

        var isValid = await validationService.Validate(payload.Text);

        if (!isValid)
            return Result<CreateStoryResponse>.Fail("O texto não atende os critérios!");

        var story = new Story
        {
            Title = payload.Title,
            Text = payload.Text,
            Writer = writer
        };

        ctx.stories.Add(story);
        await ctx.SaveChangesAsync();
        return Result<CreateStoryResponse>.Success(new());
    }
}