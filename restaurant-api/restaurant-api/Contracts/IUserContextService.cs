using System.Security.Claims;

namespace restaurant_api.Contracts
{
    public interface IUserContextService
    {
        ClaimsPrincipal User { get; }
        int? GetUserId { get; }
    }
}
