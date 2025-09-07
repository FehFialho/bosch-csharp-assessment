namespace InkFlow.UseCases.EditStory;
using System.ComponentModel.DataAnnotations;

public record EditStoryPayload{
    public string? Title { get; set; }

    [MaxLength(6000)]
    public string? Text { get; set; }
}