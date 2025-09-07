namespace InkFlow.UseCases.CreateStory;
using System.ComponentModel.DataAnnotations;
public record CreateStoryPayload
{
    [Required]
    public required string Title { get; set; }

    [Required]
    [MaxLength(6000)]
    public required string Text { get; set; }
};