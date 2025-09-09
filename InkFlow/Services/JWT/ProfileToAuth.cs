namespace InkFlow.Services.JWT;

public record ProfileToAuth(
    Guid UserID,
    string Username
);