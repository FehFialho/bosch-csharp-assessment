using System.ComponentModel.DataAnnotations;

namespace InkFlow.UseCases.CreateProfile;

public record CreateProfilePayload
{
    [Required]
    [MinLength(8)]
    [MaxLength(20)]
    public required string UserName { get; set; }

    [Required]
    [MinLength(8)]
    [MaxLength(20)]
    public required string Password { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }
    public string? WriterDescription { get; set; }

    public DateTime AccountCreation { get; set; } = DateTime.Now;
}