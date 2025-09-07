namespace ThePixeler.Models;
public class User
{
    public Guid UserID { get; set; }
    public required string Username { get; set; }
    public string ?Email { get; set; }
    public string ?WriteDescription { get; set; }
    public DateTime AccountCreation { get; set; }

}