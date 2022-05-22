using restaurant_api.Contracts;
using restaurant_api.Domain.DTOs.User;
using restaurant_api.Domain.Entities;
using restaurant_api.Infrastructure.Context;

namespace restaurant_api.Services
{
    public class AccountService : IAccountService
    {
        private readonly RestaurantDbContext _dbContext;

        public AccountService(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
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

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }
    }
}
