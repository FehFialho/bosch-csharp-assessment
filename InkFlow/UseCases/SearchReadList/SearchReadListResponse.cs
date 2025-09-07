using InkFlow.Entities;

namespace InkFlow.UseCases.SearchReadList;
public record SearchReadListResponse(
    ICollection<ReadList> ReadLists
);