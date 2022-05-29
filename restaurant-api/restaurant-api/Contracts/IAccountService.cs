using restaurant_api.Domain.DTOs.User;
using System.Threading.Tasks;

namespace restaurant_api.Contracts
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto registerUserDto);
        string GenerateJwt(LoginUserDto loginUserDto);
    }
}
