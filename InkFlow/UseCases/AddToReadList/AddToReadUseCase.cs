using InkFlow.Entities;
using Microsoft.EntityFrameworkCore;

namespace InkFlow.UseCases.AddToReadList;

public class AddToReadUseCase
(
    InkFlowDbContext ctx
)
{
    public async Task<Result<AddToReadResponse>> Do(AddToReadPayload payload)
    {

        var story = await ctx.stories.FindAsync(payload.StoryID);
        var readList = await ctx.readLists.FindAsync(payload.ReadListID);

        var storiesInList = await ctx.storyLists
            .Where(s => s.ReadListID == payload.ReadListID) // LINQ Where
            .ToListAsync();

        if (story is null)
            return Result<AddToReadResponse>.Fail("História não encontrada");

        if (readList is null)
            return Result<AddToReadResponse>.Fail("Lista não encontrada");

        if (storiesInList.Any(sl => sl.StoryID == payload.StoryID))
            return Result<AddToReadResponse>.Fail("A história já está na lista!");

        ctx.storyLists.Add(new StoryList
        {
            Story = story,
            StoryID = payload.StoryID,
            ReadList = readList,
            ReadListID = payload.ReadListID
        });
        await ctx.SaveChangesAsync();

        return Result<AddToReadResponse>.Success(new());
    }

}