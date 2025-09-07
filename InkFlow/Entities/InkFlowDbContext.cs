using Microsoft.EntityFrameworkCore;
using InkFlow.Entities;

public class InkFlowDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<History> histories => Set<History>();
    public DbSet<HistoryList> historyLists => Set<HistoryList>();
    public DbSet<User> users => Set<User>();
    public DbSet<ReadList> readLists => Set<ReadList>();

    protected override void OnModelCreating(ModelBuilder model)
    {

        model.Entity<HistoryList>()
            .HasOne(hl => hl.History)
            .WithMany(h => h.HistoryLists)
            .HasForeignKey(hl => hl.HistoryID)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<HistoryList>()
            .HasOne(hl => hl.ReadList)
            .WithMany(rl => rl.HistoryLists)
            .HasForeignKey(hl => hl.ReadListID)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<History>()
            .HasOne(h => h.Writer)
            .WithMany(w => w.Histories)
            .HasForeignKey(h => h.WriterID)
            .OnDelete(DeleteBehavior.NoAction);
    }
}