using vendsys_api.Domain.Entities;

namespace vendsys_api.Domain.Interfaces
{
    public interface IDexRepository
    {
        Task<int> SaveAsync(DexMeter meter);
    }
}
