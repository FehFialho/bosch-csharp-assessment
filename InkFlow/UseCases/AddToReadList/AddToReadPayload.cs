namespace InkFlow.UseCases.AddToReadList;
public record AddToReadPayload(
    int StoryID,
    int ReadListID
);