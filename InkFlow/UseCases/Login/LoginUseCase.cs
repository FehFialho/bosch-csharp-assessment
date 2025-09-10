using InkFlow.Services.JWT;
using InkFlow.Services.Password;
using ThePixeler.Services.Profiles;

namespace InkFlow.UseCases.Login;
public class LoginUseCase(
    IProfilesService profilesService,
    IPasswordServices passwordService,
    IJWTService jwtService
)
{
    public async Task<Result<LoginResponse>> Do(LoginPayload payload)
    {
        var user = await profilesService.FindByLogin(payload.Login);
        Console.WriteLine(user == null ? "User not found" : $"Found user: {user.Username}");

        if (user is null)
            return Result<LoginResponse>.Fail("User not found!");

        var passwordMatch = passwordService.Compare(payload.Password, user.Password);
        Console.WriteLine($"Password match: {passwordMatch}");

        if (!passwordMatch)
            return Result<LoginResponse>.Fail("Wrong Password!");

        // 
        var jwt = jwtService.CreateToken(new(
            user.UserID, user.Username
        ));

        // Se tudo der certo, retorna o JWT
        return Result<LoginResponse>.Success(new LoginResponse(jwt));
    }
}