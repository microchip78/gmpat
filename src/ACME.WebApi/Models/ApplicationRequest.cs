using System.ComponentModel.DataAnnotations;

namespace ACME.WebApi.Models
{
    public class ApplicationRequest
    {
        [Required]
        public string CountryName { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Postcode { get; set; }
    }
}