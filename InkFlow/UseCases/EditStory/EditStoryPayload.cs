namespace InkFlow.UseCases.EditStory;
using System.ComponentModel.DataAnnotations;

public record EditStoryPayload(
    string? Title,
    string? Text
);