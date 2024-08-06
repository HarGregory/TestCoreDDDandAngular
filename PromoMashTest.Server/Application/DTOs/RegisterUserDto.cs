namespace PromoMashTest.Server.Application.DTOs
{
    public class RegisterUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        //public bool IsAgree { get; set; }
        public int CountryId { get; set; }
        public int ProvinceId { get; set; }
    }
}
