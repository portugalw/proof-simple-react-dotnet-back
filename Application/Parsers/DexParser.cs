using System.Diagnostics;
using System.Globalization;
using vendsys_api.Domain.Entities;

namespace vendsys_api.Application.Parsers
{
    public class DexParser : IDexParser
    {
        // EXTRACT VALUES FROM FILE
        public DexMeter Parse(string content)
        {
            var meter = new DexMeter
            {
                DexDateTime = DateTime.UtcNow
            };

            foreach (var line in content.Split(Environment.NewLine))
            {
               

                if (line.StartsWith("ID1"))
                {
                    var parts = line.Split('*');

                    meter.MachineSerialNumber = parts.Length > 1 ? parts[1] : "";
                    meter.MachineId = parts.Length > 6 ? parts[6] : "";
                }


                if (line.StartsWith("VA101"))
                    meter.ValueOfPaidVends = decimal.Parse(line[5..]) / 100;

                if (line.StartsWith("PA"))
                {
                    var parts = line.Split('*');

                    Debug.WriteLine(line);

                    var culture = CultureInfo.InvariantCulture;
                    var priceRaw = 0m;
                    var valueOfPaidSalesRaw = 0m;
                    var numberOfVends = 0;

                    bool priceOk = parts.Length > 2 && decimal.TryParse(parts[2], NumberStyles.Any, culture, out priceRaw);
                    bool numberVendsOk = parts.Length > 3 && int.TryParse(parts[3], NumberStyles.Any, culture, out  numberOfVends);
                    bool salesOk = parts.Length > 4 && decimal.TryParse(parts[4], NumberStyles.Any, culture, out  valueOfPaidSalesRaw);

                    var laneMeter = new DexLaneMeter
                    {
                        ProductIdentifier = parts[1],
                        Price = priceOk ? priceRaw / 100m : 0,
                        NumberOfVends = numberOfVends,
                        ValueOfPaidSales = salesOk ? valueOfPaidSalesRaw / 100m : 0
                    };

                    meter.LaneMeters.Add(laneMeter);
                    meter.ValueOfPaidVends += laneMeter.ValueOfPaidSales;


                }
            }
            
            return meter;
        }
    }
}
