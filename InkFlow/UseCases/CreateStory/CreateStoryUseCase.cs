using InkFlow;
using InkFlow.Entities;
using InkFlow.UseCases.CreateStory;

public class CreateStoryUseCase(
        InkFlowDbContext ctx
    )
{
    public async Task<Result<CreateStoryResponse>> Do(CreateStoryPayload payload)
    {
        var writer = await ctx.users.FindAsync(payload.WriterID);

        if (writer is null)
            return Result<CreateStoryResponse>.Fail("Usuário não encontrado");

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