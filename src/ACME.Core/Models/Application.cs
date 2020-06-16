using System;

namespace ACME.Core.Models
{
    public class Application
    {
        public int Id { get; set; }

        public int CountryId { get; set; }

        public int? PostcodeId { get; set; }

        public string FullName { get; set; }

        public DateTime? DateTimeCreated { get; set; }
    }
}