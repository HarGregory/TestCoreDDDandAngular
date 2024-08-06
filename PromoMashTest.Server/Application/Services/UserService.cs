using PromoMashTest.Server.Application.DTOs;
using PromoMashTest.Server.Application.Interfaces;
using PromoMashTest.Server.Core.Entities;
using PromoMashTest.Server.Core.Interfaces;

namespace PromoMashTest.Server.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task RegisterUserAsync(RegisterUserDto dto)
        {
            if (dto.Password != dto.ConfirmPassword)
            {
                throw new ArgumentException("Passwords do not match.");
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                //IsAgree = dto.IsAgree,
                CountryId = dto.CountryId,
                ProvinceId = dto.ProvinceId
            };

            await _userRepository.AddAsync(user);
        }
    }
}
