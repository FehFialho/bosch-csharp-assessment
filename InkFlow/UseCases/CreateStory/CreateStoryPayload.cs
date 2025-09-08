namespace InkFlow.UseCases.CreateStory;
public record CreateStoryPayload(
    string Title,
    string Text,
    Guid WriterID
);
