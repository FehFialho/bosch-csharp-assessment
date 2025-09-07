using Microsoft.EntityFrameworkCore;
using InkFlow.Entities;

public class InkFlowDbContext : DbContext
{
    public InkFlowDbContext(DbContextOptions<InkFlowDbContext> options) : base(options) { }

    public DbSet<Story> stories => Set<Story>();
    public DbSet<StoryList> storyLists => Set<StoryList>();
    public DbSet<User> users => Set<User>();
    public DbSet<ReadList> readLists => Set<ReadList>();

    protected override void OnModelCreating(ModelBuilder model)
    {
        // Relacionamento StoryList ↔ Story
        model.Entity<StoryList>()
            .HasOne(sl => sl.Story)
            .WithMany(s => s.StoryLists)
            .HasForeignKey(sl => sl.StoryID)
            .OnDelete(DeleteBehavior.NoAction);

        // Relacionamento StoryList ↔ ReadList
        model.Entity<StoryList>()
            .HasOne(sl => sl.ReadList)
            .WithMany(rl => rl.StoryLists)
            .HasForeignKey(sl => sl.ReadListID)
            .OnDelete(DeleteBehavior.NoAction);

        // Relacionamento Story ↔ Writer (User)
        model.Entity<Story>()
            .HasOne(s => s.Writer)
            .WithMany(w => w.Stories)
            .HasForeignKey(s => s.WriterID)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
