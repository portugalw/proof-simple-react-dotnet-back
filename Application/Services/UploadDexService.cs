using vendsys_api.Application.Parsers;
using vendsys_api.Domain.Interfaces;

namespace vendsys_api.Application.Services
{
    public class UploadDexService : IUploadDexService
    {
        private readonly IDexParser _parser;
        private readonly IDexRepository _dexRepository;
        private readonly IDexLaneRepository _dexLaneRepository;

        public UploadDexService(IDexParser parser, IDexRepository dexRepository, IDexLaneRepository dexLaneRepository)
        {
            _parser = parser;
            _dexRepository = dexRepository;
            _dexLaneRepository = dexLaneRepository;
        }

        public async Task ProcessAsync(IFormFile dexFile)
        {
            using var reader = new StreamReader(dexFile.OpenReadStream());
            var content = await reader.ReadToEndAsync();

            var meter = _parser.Parse(content);
            var dexMeterId = await _dexRepository.SaveAsync(meter);
            await _dexLaneRepository.SaveAsync(dexMeterId, meter.LaneMeters);

        }
    }
}
