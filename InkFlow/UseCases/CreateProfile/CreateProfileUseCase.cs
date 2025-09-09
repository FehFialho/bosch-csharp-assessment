using InkFlow.Entities;
using InkFlow.Services.Password;
using ThePixeler.Services.Profiles;

namespace InkFlow.UseCases.CreateProfile;

public class CreateProfileUseCase
(
    IProfilesService profilesService,
    IPasswordServices passwordService
)
{
    public async Task<Result<CreateProfileResponse>> Do(CreateProfilePayload payload)
    {
        Console.Write(payload);
        var user = new User
        {
            Username = payload.UserName,
            Password = passwordService.Hash(payload.Password),
            Email = payload.Email,
            WriterDescription = payload.WriterDescription,
            AccountCreation = payload.AccountCreation
        };

        await profilesService.Create(user);
        return Result<CreateProfileResponse>.Success(new());
    }

}