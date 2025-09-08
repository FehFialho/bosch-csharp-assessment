namespace InkFlow.UseCases.DeleteStory;
public class DeleteStoryUseCase(
        InkFlowDbContext ctx
    )
{
    public async Task<Result<DeleteStoryResponse>> Do(DeleteStoryPayload payload)
    {
        var story = await ctx.stories.FindAsync(payload.StoryID);

        if (story is null)
            return Result<DeleteStoryResponse>.Fail("História não encontrada");

        ctx.stories.Remove(story);
        await ctx.SaveChangesAsync();
        
        return Result<DeleteStoryResponse>.Success(new DeleteStoryResponse
        {
            StoryID = payload.StoryID
        });
    }
}