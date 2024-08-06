namespace PromoMashTest.Server.Core.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        //public bool IsAgree { get; set; }
        public int CountryId { get; set; }
        public int ProvinceId { get; set; }

    }

}
