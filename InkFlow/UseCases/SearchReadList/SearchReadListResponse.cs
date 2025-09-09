using InkFlow.Entities;

namespace InkFlow.UseCases.SearchReadList;

public record SearchReadListResponse
{
    public ICollection<ReadList> ReadLists { get; init; } = new List<ReadList>();
}
