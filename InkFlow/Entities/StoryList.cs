namespace InkFlow.Entities;

public class StoryList
{
    public int StoryListID { get; set; }
    public int ReadListID { get; set; }
    public int StoryID { get; set; }

    public required Story Story { get; set; }
    public required ReadList ReadList { get; set; }
}
