using Microsoft.EntityFrameworkCore;
using ThePixeler.Models;

public class InkFlowDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<History> histories => Set<History>();
    public DbSet<HistoryList> historyLists => Set<HistoryList>();
    public DbSet<User> users => Set<User>();
    public DbSet<ReadList> readLists => Set<ReadList>();

    protected override void OnModelCreating(ModelBuilder model)
    {
        base.OnModelCreating(model);
    }

}