using Microsoft.AspNetCore.Identity;
using restaurant_api.Contracts;
using restaurant_api.Domain.DTOs.User;
using restaurant_api.Domain.Entities;
using restaurant_api.Infrastructure.Context;

namespace restaurant_api.Services
{
    public class AccountService : IAccountService
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountService(RestaurantDbContext dbContext, IPasswordHasher<User> passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }
        public void RegisterUser(RegisterUserDto registerUserDto)
        {
            var newUser = new User()
            {
                Email = registerUserDto.Email,
                DateBirth = registerUserDto.DateOfBirth,
                Nationality = registerUserDto.Nationality,
                RoleId = registerUserDto.RoleId,
            };

            var hashedPassword = _passwordHasher.HashPassword(newUser, registerUserDto.Password);

            newUser.PasswordHash = hashedPassword;
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }
    }
}
