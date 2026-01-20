using vendsys_api.Domain.Entities;

namespace vendsys_api.Application.Parsers
{
    public interface IDexParser
    {
        DexMeter Parse(string dexContent);
    }
}
