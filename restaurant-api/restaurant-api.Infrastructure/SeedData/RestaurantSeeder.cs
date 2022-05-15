using restaurant_api.Domain.Entities;
using restaurant_api.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant_api.Domain.SeedData
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;
        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Manager"
                },
                new Role()
                {
                    Name = "Admin"
                }
            };

            return roles;
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "McDonald",
                    Category = "Fast Food",
                    Description = "McDonald's (MCD) is a fast food, limited service restaurant with more than 35,000 restaurants in over 100 countries." +
                    "It employs more than four million people. McDonald's serves 70 million customers per day, which is greater than the population of France.",
                    ContactEmail = "contact@mcdonalds.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "McChicken",
                            Price = 5.99M
                        },
                        new Dish()
                        {
                            Name = "Big Mac",
                            Price = 6.99M
                        }
                    },
                    Address = new Address()
                    {
                        City = "Bielsko-Biała",
                        Street = "Wyzwolenia 2",
                        PostalCode = "43-300"
                    }
                },
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description =
                        "KFC (short for Kentucky Fried Chicken) is an American fast food restaurant chain headquartered in Louisville, Kentucky, that specializes in fried chicken.",
                    ContactEmail = "contact@kfc.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Nashville Hot Chicken",
                            Price = 10.30M,
                        },

                        new Dish()
                        {
                            Name = "Chicken Nuggets",
                            Price = 5.30M,
                        },
                    },
                    Address = new Address()
                    {
                        City = "Kraków",
                        Street = "Długa 5",
                        PostalCode = "30-001"
                    }
                 },
                 new Restaurant()
                 {
                    Name = "Zielona Krowa",
                    Category = "Fast Food",
                    Description =
                        "Restauracja która preferuje ekologiczne, lokalne produkty bez chemicznych dodatków i konserwantów." +
                        "Głównie burgery, sandwiche i sałatki. A także pyszne śniadania i zestawy lunchowe. Sosy przygotowujemy według własnych receptur.",
                    ContactEmail = "contact@mcdonald.com",
                    HasDelivery = true,
                    Address = new Address()
                    {
                        City = "Bielsko-Biała",
                        Street = "Szewska 2",
                        PostalCode = "43-300"
                    }
                 }
            };
            return restaurants;
        }
    }
}
