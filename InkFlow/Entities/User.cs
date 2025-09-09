namespace InkFlow.Entities;

public class User
{
    public Guid UserID { get; set; }
    public required string Username { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? WriteDescription { get; set; }
    public DateTime AccountCreation { get; set; }

    public ICollection<Story>? Stories { get; set; }  // Antes: Histories
    public ICollection<ReadList>? ReadLists { get; set; }
}
