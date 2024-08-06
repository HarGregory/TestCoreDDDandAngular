using System.Text.Json.Serialization;

namespace PromoMashTest.Server.Core.Entities
{
    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        [JsonIgnore]
        public Country Country { get; set; }
    }
}
