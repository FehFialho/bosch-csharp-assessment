namespace InkFlow.Entities;

public class ReadList
{
    public int ReadListID { get; set; }
    public required string Title { get; set; }
    public DateTime LastModification { get; set; }

    public required User Author { get; set; }
    public ICollection<StoryList> StoryLists { get; set; } = new List<StoryList>();

}
