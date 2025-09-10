using Microsoft.AspNetCore.Identity;

namespace InkFlow.Services.Password;

public class PBKDF2PasswordService : IPasswordServices
{
    readonly PasswordHasher<string> hasher = new();
    public bool Compare(string password, string hash)
    {
        var result = hasher.VerifyHashedPassword(null, hash, password);
        return result == PasswordVerificationResult.Success;
    }

    public string Hash(string password)
        => hasher.HashPassword(null, password);

}