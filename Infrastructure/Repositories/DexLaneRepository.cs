using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using vendsys_api.Domain.Entities;
using vendsys_api.Domain.Interfaces;
using vendsys_api.Infrastructure.Data;

namespace vendsys_api.Infrastructure.Repositories
{
    public class DexLaneRepository : IDexLaneRepository
    {
        private readonly AppDbContext _context;

        public DexLaneRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Saves all lane meters related to a DEX meter using STORE PROCEDURE
        /// </summary>
        public async Task SaveAsync(int dexMeterId, IEnumerable<DexLaneMeter> lanes)
        {
            foreach (var lane in lanes)
            {
                var parameters = new[]
                {
                new SqlParameter("@DexMeterId", dexMeterId),
                new SqlParameter("@ProductIdentifier", lane.ProductIdentifier),
                new SqlParameter("@Price", lane.Price),
                new SqlParameter("@NumberOfVends", lane.NumberOfVends),
                new SqlParameter("@ValueOfPaidSales", lane.ValueOfPaidSales)
            };

                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC SaveDexLaneMeter @DexMeterId, @ProductIdentifier, @Price, @NumberOfVends, @ValueOfPaidSales",
                    parameters
                );
            }
        }
    }
}
