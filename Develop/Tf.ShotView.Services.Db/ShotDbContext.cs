using Microsoft.EntityFrameworkCore;
using Tf.ShotView.Models.Db;
namespace Tf.ShotView.Services.Db;

public class ShotDbContext : DbContext
{
    public DbSet<RawShot>? RawShots { get; set; } = null;

    public string DbPath { get; }

    public ShotDbContext(DbContextOptions<ShotDbContext> options) : base(options)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "shotview.db");
    }

    public ShotDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "shotview.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
