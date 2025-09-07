namespace ThePixeler.Models;

public class HistoryList
{
    public int HistoryListID { get; set; }
    public int ReadListID { get; set; }
    public int HistoryID { get; set; }

    public required History History { get; set; }
    public required ReadList ReadList { get; set; }
}