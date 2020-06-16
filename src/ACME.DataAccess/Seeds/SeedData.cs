using Microsoft.EntityFrameworkCore;
using ACME.Core.Models;

namespace ACME.DataAccess.Seeds
{
    public static class SeedData
    {
        public static void InitializeData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = 1, CountryName = "Australia", CountryCode = "AU" },
                new Country { CountryId = 2, CountryName = "New Zealand", CountryCode = "NZ" },
                new Country { CountryId = 3, CountryName = "Antarctica", CountryCode = "AQ" },
                new Country { CountryId = 4, CountryName = "Argentina", CountryCode = "AR" },
                new Country { CountryId = 5, CountryName = "Brazil", CountryCode = "BR" },
                new Country { CountryId = 6, CountryName = "Australia", CountryCode = "AU" },
                new Country { CountryId = 7, CountryName = "New Zeland", CountryCode = "NZ" },
                new Country { CountryId = 8, CountryName = "Antarticia", CountryCode = "AQ" },
                new Country { CountryId = 9, CountryName = "Argentina", CountryCode = "AR" },
                new Country { CountryId = 10, CountryName = "Brazil", CountryCode = "BR" }
            );

            modelBuilder.Entity<Postcode>().HasData(
                new Postcode { ID = 50, Pcode = "822", Locality = "ACACIA HILLS", State = "NT", Comments = null, DeliveryOffice = null, PreSortIndicator = null, ParcelZone = null, BSPnumber = null, BSPname = null, Category = "Delivery Area" },
                new Postcode { ID = 3802, Pcode = "2601", Locality = "ACTON", State = "ACT", Comments = null, DeliveryOffice = null, PreSortIndicator = null, ParcelZone = null, BSPnumber = null, BSPname = null, Category = "Delivery Area" },
                new Postcode { ID = 5172, Pcode = "2850", Locality = "AARONS PASS", State = "NSW", Comments = null, DeliveryOffice = null, PreSortIndicator = null, ParcelZone = null, BSPnumber = null, BSPname = null, Category = "Delivery Area" },
                new Postcode { ID = 7795, Pcode = "3737", Locality = "ABBEYARD", State = "VIC", Comments = null, DeliveryOffice = null, PreSortIndicator = null, ParcelZone = null, BSPnumber = null, BSPname = null, Category = "Delivery Area" },
                new Postcode { ID = 10354, Pcode = "4613", Locality = "ABBEYWOOD", State = "QLD", Comments = null, DeliveryOffice = null, PreSortIndicator = null, ParcelZone = null, BSPnumber = null, BSPname = null, Category = "Delivery Area" },
                new Postcode { ID = 12392, Pcode = "5159", Locality = "ABERFOYLE PARK", State = "SA", Comments = null, DeliveryOffice = null, PreSortIndicator = null, ParcelZone = null, BSPnumber = null, BSPname = null, Category = "Delivery Area" },
                new Postcode { ID = 14504, Pcode = "6280", Locality = "ABBA RIVER", State = "WA", Comments = null, DeliveryOffice = null, PreSortIndicator = null, ParcelZone = null, BSPnumber = null, BSPname = null, Category = "Delivery Area" },
                new Postcode { ID = 16305, Pcode = "7306", Locality = "ACACIA HILLS", State = "TAS", Comments = null, DeliveryOffice = null, PreSortIndicator = null, ParcelZone = null, BSPnumber = null, BSPname = null, Category = "Delivery Area" },
                new Postcode { ID = 16361, Pcode = "7315", Locality = "ABBOTSHAM", State = "TAS", Comments = null, DeliveryOffice = null, PreSortIndicator = null, ParcelZone = null, BSPnumber = null, BSPname = null, Category = "Delivery Area" },
                new Postcode { ID = 16389, Pcode = "7320", Locality = "ACTON", State = "TAS", Comments = "BURNIE", DeliveryOffice = null, PreSortIndicator = null, ParcelZone = null, BSPnumber = null, BSPname = null, Category = "Delivery Area" }
            );
        }
    }
}