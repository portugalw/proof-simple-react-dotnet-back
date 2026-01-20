using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using vendsys_api.Domain.Entities;
using vendsys_api.Domain.Interfaces;
using vendsys_api.Infrastructure.Data;

namespace vendsys_api.Infrastructure.Repositories
{
    public class DexRepository : IDexRepository
    {
        private readonly AppDbContext _context;

        public DexRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Saves the DEX meter header and returns the generated primary key.
        /// </summary>
        /// <summary>
        /// Saves the DEX meter header and returns the generated DEXMeterId.
        /// </summary>
        public async Task<int> SaveAsync(DexMeter meter)
        {
            // Input parameters
            var machineIdParam = new SqlParameter("@MachineId", meter.MachineId);
            var dexDateTimeParam = new SqlParameter("@DEXDateTime", meter.DexDateTime);
            var serialParam = new SqlParameter("@MachineSerialNumber", meter.MachineSerialNumber);
            var valueParam = new SqlParameter("@ValueOfPaidVends", meter.ValueOfPaidVends);

            // Output parameter
            var dexMeterIdParam = new SqlParameter("@DEXMeterId", System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };

            // Execute stored procedure
            await _context.Database.ExecuteSqlRawAsync(
                @"EXEC SaveDEXMeter
                @MachineId,
                @DEXDateTime,
                @MachineSerialNumber,
                @ValueOfPaidVends,
                @DEXMeterId OUTPUT",
                machineIdParam,
                dexDateTimeParam,
                serialParam,
                valueParam,
                dexMeterIdParam
            );

            // Retrieve OUTPUT value
            return (int)dexMeterIdParam.Value;
        }
    }
}
