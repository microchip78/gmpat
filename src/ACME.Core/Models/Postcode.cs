namespace ACME.Core.Models
{
    public class Postcode
    {
        public int ID { get; set; }

        public string Pcode { get; set; }

        public string Locality { get; set; }

        public string State { get; set; }

        public string Comments { get; set; }

        public string DeliveryOffice { get; set; }

        public string PreSortIndicator { get; set; }

        public string ParcelZone { get; set; }

        public string BSPnumber { get; set; }

        public string BSPname { get; set; }

        public string Category { get; set; }
    }
}