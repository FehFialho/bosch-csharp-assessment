using InkFlow.Services.JWT;
namespace Inkflow.Services.JWT;

public interface IJWTService
{
    string CreateToken(ProfileToAuth data);
}