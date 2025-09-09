using InkFlow.Entities;
using Microsoft.EntityFrameworkCore;

namespace ThePixeler.Services.Profiles;

public class EFProfileService(InkFlowDbContext ctx) : IProfilesService
{
    public async Task<Guid> Create(User profile)
    {
        ctx.users.Add(profile);
        await ctx.SaveChangesAsync();
        return profile.UserID;
    }

    public async Task<User> FindByLogin(string login)
    {
        var profile = await ctx.users.FirstOrDefaultAsync(
            p => p.Username == login || p.Email == login
        );
        return profile;
    }
}