namespace InkFlow.UseCases.SearchReadList;
public record SearchReadListPayload(
    string? ReadListTitle,
    string? StoryTitle,
    string? WriterName,
    DateTime LastModification
);