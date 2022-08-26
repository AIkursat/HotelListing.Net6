using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Models.Country
{
    public class BaseCountryDto
    {
        [Required]
        public int Name { get; set; } 
        public string ShortName { get; set; }
    }
}
