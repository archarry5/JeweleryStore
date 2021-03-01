using JeweleryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeweleryStore.Helpers
{
    public class PrivilegedDiscountStrategy : IDiscountStrategy {
        

        public double GetDiscountPerc(CustomUser user) {
            if (user.IsPrivileged) {
                return 2.0;
            }
            return 0;
        }
    }
}
