namespace vendsys_api.Domain.Entities
{
    public class DexLaneMeter
    {
        public int Id { get; set; }

        public int DexMeterId { get; set; }
        public DexMeter DexMeter { get; set; } = null!;

        public string ProductIdentifier { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int NumberOfVends { get; set; }
        public decimal ValueOfPaidSales { get; set; }
    }
}
