using Tf.ShotView.Models.Db;

namespace Tf.ShotView.Models.Services;

public interface IDbService
{
    Task<RawShot?> GetRawShot(string id);
    Task<IList<RawShot>> GetRawShotsByLaneAndDay(int day, int lane);
    
    Task<int> AddRawShot(RawShot rawShot);
    Task<int> AddRawShots(IList<RawShot> rawShots);
    
    Task<int> UpdateRawShot(RawShot rawShot);
    Task<int> UpdateRawShots(IList<RawShot> rawShots);
    
    Task<int> DeleteRawShot(string id);

    Task<IList<int>> SelectDays();
    Task<IList<int>> SelectLanes(int day);

    Task<IList<DTO.Passe>> SelectPassen(int day);
    Task<IList<DTO.Match>> SelectMatchs(int day);
}
