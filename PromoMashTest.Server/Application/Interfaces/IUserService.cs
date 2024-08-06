using PromoMashTest.Server.Application.DTOs;

namespace PromoMashTest.Server.Application.Interfaces
{
    public interface IUserService
    {
        Task RegisterUserAsync(RegisterUserDto dto);
    }
}
