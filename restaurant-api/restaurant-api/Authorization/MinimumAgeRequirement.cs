using Microsoft.AspNetCore.Authorization;

namespace restaurant_api.Authorization
{
    public class MinimumAgeRequirement : IAuthorizationRequirement
    {
        public int MinimumAge { get; }

        public MinimumAgeRequirement(int age)
        {
            MinimumAge = age;
        }
    }
}
