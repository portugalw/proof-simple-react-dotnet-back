using vendsys_api.Domain.Entities;

namespace vendsys_api.Domain.Interfaces
{
    public interface IDexLaneRepository
    {
        Task SaveAsync(int dexMeterId, IEnumerable<DexLaneMeter> lanes);
    }
}
