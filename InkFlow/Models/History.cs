namespace ThePixeler.Models;
public class History
{
    public int HistoryID { get; set; }
    public int WriterID { get; set; }
    public required string Title { get; set; }
    public required string Text { get; set; }
}