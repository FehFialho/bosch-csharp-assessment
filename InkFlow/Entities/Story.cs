namespace InkFlow.Entities;

public class Story
{
    public int StoryID { get; set; }
    public Guid WriterID { get; set; }
    public required string Title { get; set; }
    public required string Text { get; set; }

    public required User Writer { get; set; }
    public ICollection<StoryList>? StoryLists { get; set; } // tabela de junção
}
