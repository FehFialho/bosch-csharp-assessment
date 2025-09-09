namespace InkFlow.UseCases.EditStory;
using System.ComponentModel.DataAnnotations;

public record EditStoryPayload(
    int StoryID,
    string? Title,
    string? Text
);