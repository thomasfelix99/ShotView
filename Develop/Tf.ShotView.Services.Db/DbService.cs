using Microsoft.EntityFrameworkCore;
using Tf.ShotView.Models.Db;
using Tf.ShotView.Models.DTO;
using Tf.ShotView.Models.Services;

namespace Tf.ShotView.Services.Db;

public class DbService : IDbService
{
    private readonly ShotDbContext _db;

    public DbService(ShotDbContext dbContext)
    {
        _db = dbContext;
    }

    public async Task<RawShot?> GetRawShot(string id)
    {
        return await _db.RawShots!.FindAsync(id);
    }

    public async Task<int> DeleteRawShot(string id)
    {
        var rawShot = await GetRawShot(id);
        if (rawShot == null)
        {
            return 0;
        }

        _db.RawShots!.Remove(rawShot);

        return await _db.SaveChangesAsync(true);
    }

    public async Task<int> AddRawShot(RawShot rawShot)
    {
        _db.RawShots!.Add(rawShot);
        return await _db.SaveChangesAsync(true);
    }

    public async Task<int> AddRawShots(IList<RawShot> rawShots)
    {
        _db.RawShots!.AddRange(rawShots);
        return await _db.SaveChangesAsync(true);
    }

    public async Task<int> UpdateRawShot(RawShot rawShot)
    {
        _db.RawShots!.Update(rawShot);
        return await _db.SaveChangesAsync(true);
    }

    public async Task<int> UpdateRawShots(IList<RawShot> rawShots)
    {
        foreach (RawShot rawShot in rawShots)
        {
            _db.RawShots!.Update(rawShot);
        }
        return await _db.SaveChangesAsync(true);
    }
    
    public async Task<IList<RawShot>> GetRawShotsByLaneAndDay(int day, int lane)
    {
        return await _db.RawShots!
            .Where(r => r.Day == day && r.BahnNr == lane)
            .ToListAsync();
    }

    public async Task<IList<RawShot>> GetRawShotsByPasseId(string passeId)
    {
        return await _db.RawShots!
            .Where(r => r.PasseId.Equals(passeId))
            .ToListAsync();
    }

    public async Task<IList<int>> SelectDays()
    {
        return await _db.RawShots!
            .GroupBy(r => r.Day)
            .Select(r => r.Key)
            .ToListAsync();
    }

    public async Task<IList<int>> SelectLanes(int day)
    {
        return await _db.RawShots!
            .Where(r => r.Day == day)
            .GroupBy(r => r.BahnNr)
            .Select(r => r.Key)
            .ToListAsync();
    }

    public async Task<IList<Passe>> SelectPassen(int day)
    {
        //return await _db.RawShots
        //    .Where(r => r.Day == day)
        //    .GroupBy(r => r.PasseId)
        //    .Distinct();

        throw new NotImplementedException();
    }

    public async Task<IList<Match>> SelectMatchs(int day)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<RawShot>> SelectPasse(int day, int lane)
    {
        return await _db.RawShots!
            .Where(r => r.Day == day && r.BahnNr == lane)
            .OrderBy(r => r.LogEvent)
            .ToListAsync();
    }
}

