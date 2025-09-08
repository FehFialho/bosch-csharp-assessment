namespace ThePixeler.Services.JWT;

public record ProfileToAuth(
    Guid ProfileId,
    string Username,
    int SubscriptionID
);