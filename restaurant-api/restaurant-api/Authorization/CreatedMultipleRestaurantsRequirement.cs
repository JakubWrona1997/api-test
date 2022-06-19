using Microsoft.AspNetCore.Authorization;

namespace restaurant_api.Authorization
{
    public class CreatedMultipleRestaurantsRequirement : IAuthorizationRequirement
    {
        public CreatedMultipleRestaurantsRequirement(int minimumRestaurantsCreated)
        {
            MinimumRestaurantsCreated = minimumRestaurantsCreated;
        }
        public int MinimumRestaurantsCreated { get; }
    }
}
