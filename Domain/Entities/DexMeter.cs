namespace vendsys_api.Domain.Entities
{
    public class DexMeter
    {
        public int Id { get; set; }

        public string MachineId { get; set; }
        public DateTime DexDateTime { get; set; }
        public string MachineSerialNumber { get; set; } = string.Empty;
        public decimal ValueOfPaidVends { get; set; }

        public ICollection<DexLaneMeter> LaneMeters { get; set; } = new List<DexLaneMeter>();
    }
}
