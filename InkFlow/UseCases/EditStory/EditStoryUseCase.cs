namespace InkFlow.UseCases.EditStory;
public class EditStoryUseCase(
        InkFlowDbContext ctx
    )
{
    public async Task<Result<EditStoryResponse>> Do(EditStoryPayload payload)
    {

        var story = await ctx.stories.FindAsync(payload.StoryID);

        if (story is null)
            return Result<EditStoryResponse>.Fail("História não encontrada");
            
        if (payload.Text is not null)
            story.Text = payload.Text; // Apply Service Later

        if (payload.Title is not null)
            story.Title = payload.Title; // Apply Service Later

        await ctx.SaveChangesAsync();

        return Result<EditStoryResponse>.Success(new());
    }
}