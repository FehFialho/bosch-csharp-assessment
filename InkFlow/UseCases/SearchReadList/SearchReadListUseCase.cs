using InkFlow.Entities;
using Microsoft.EntityFrameworkCore;

namespace InkFlow.UseCases.SearchReadList;

public class SearchReadListUseCase(InkFlowDbContext ctx)
{
    public async Task<Result<SearchReadListResponse>> Do(SearchReadListPayload payload)
    {
        // Basis Query
        var query = ctx.readLists.AsQueryable();

        // Filters

        // ReadList Title
        if (!string.IsNullOrWhiteSpace(payload.ReadListTitle))
        {
            query = query.Where(rl => rl.Title.Contains(payload.ReadListTitle));
        }

        // Author
        if (!string.IsNullOrWhiteSpace(payload.AuthorName))
        {
            query = query.Where(rl => rl.Author.Username.Contains(payload.AuthorName));
        }

        // Story Title
        if (!string.IsNullOrWhiteSpace(payload.StoryTitle))
        {
            query = query.Where(rl => rl.StoryLists
                                        .Any(hl => hl.Story.Title.Contains(payload.StoryTitle)));
        }

        // Last Modification
        if (payload.LastModification.HasValue)
        {
            query = query.Where(rl => rl.LastModification.Date == payload.LastModification.Value.Date);
        }

        // Include Data
        query = query
            .Include(rl => rl.Author)
            .Include(rl => rl.StoryLists)
                .ThenInclude(sl => sl.Story)
                    .ThenInclude(s => s.Writer);

        // Execute Query
        var readLists = await query.ToListAsync();

        // Return
        return Result<SearchReadListResponse>.Success(new SearchReadListResponse
        {
            ReadLists = readLists
        });
    }
}
