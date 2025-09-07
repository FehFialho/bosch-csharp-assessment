namespace ThePixeler.Models;

public class ReadList
{
    public int ReadListID { get; set; }
    public required string Title { get; set; }
    public DateTime LastModification { get; set; }

    public required User Author { get; set; }
    public ICollection<HistoryList>? HistoryLists { get; set; }

}