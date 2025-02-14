using Microsoft.EntityFrameworkCore;
using virtusstructura_backend.Data;
using virtusstructura_backend.Dtos.UserDtos;
using virtusstructura_backend.Models;

namespace virtusstructura_backend.Services
{
    public class UserService
    {
        private readonly AppDbContext _appDbContext;
        private readonly JwtService _jwtService;

        public UserService(AppDbContext appDbContext, JwtService jwtService)
        {
            _appDbContext = appDbContext;
            _jwtService = jwtService;
        }

        public async Task<UserReturnDto?> AddUserAsync(UserRegisterDto userRegisterDto)
        {
            if (userRegisterDto == null)
                throw new InvalidOperationException("Ocorreu um erro ao registrar o usuário.");

            if (await _appDbContext.Users.AnyAsync(u => u.Email == userRegisterDto.Email))
                throw new InvalidOperationException("Já existe um usuário cadastrado com esse e-mail.");

            if (userRegisterDto.Age < 0 || userRegisterDto.Age > 120)
                throw new InvalidOperationException("A idade é inválida");

            var user = new User
            {
                Name = userRegisterDto.Name,
                Email = userRegisterDto.Email,
                Age = userRegisterDto.Age,
                Weight = userRegisterDto.Weight,
                Height = userRegisterDto.Height,
                ExperienceLevel = userRegisterDto.ExperienceLevel
            };

            user.SetPassword(userRegisterDto.Password);
            user.SetUpdatedAt();

            _appDbContext.Users.Add(user);
            await _appDbContext.SaveChangesAsync();

            return new UserReturnDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Age = user.Age,
                Weight = user.Weight,
                Height = user.Height,
                ExperienceLevel = user.ExperienceLevel,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }
    }
}
