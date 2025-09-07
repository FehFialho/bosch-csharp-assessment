namespace ThePixeler.Models;

public class History
{
    public int HistoryID { get; set; }
    public Guid WriterID { get; set; }
    public required string Title { get; set; }
    public required string Text { get; set; }

    public required User Writer { get; set; }
    public ICollection<HistoryList>? HistoryLists { get; set; }

}