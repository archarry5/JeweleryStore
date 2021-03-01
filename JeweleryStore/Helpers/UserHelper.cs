using JeweleryStore.Models;
using JeweleryStore.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeweleryStore.Helpers {

    public static class DataSeeder {
        public static void SeedUserData(UserManager<CustomUser> userManager) {
            if (userManager.FindByNameAsync("user1").Result == null) {
                CustomUser user = new CustomUser {
                    UserName = "user1",
                    IsPrivileged = true
                };

                IdentityResult result = userManager.CreateAsync(user, "pass1").Result;
            }

            if (userManager.FindByNameAsync("user2").Result == null) {
                CustomUser user = new CustomUser {
                    UserName = "user2",
                    IsPrivileged = false
                };

                IdentityResult result = userManager.CreateAsync(user, "pass2").Result;
            }
        }
    }
    public class UserHelper : IUserHelper {
        readonly UserDbContext context;
        IDiscountStrategy discountStrategy;
        
        public UserHelper(UserDbContext context, IDiscountStrategy discountStrategy) {
            this.context = context;
            this.discountStrategy = discountStrategy;
        }

        public double GetDiscountPerc(CustomUser user) {
            return discountStrategy.GetDiscountPerc(user);
        }

        public void ChangeDiscountStrategy(IDiscountStrategy newStrategy) {
            discountStrategy = newStrategy;
        }
    }
}
