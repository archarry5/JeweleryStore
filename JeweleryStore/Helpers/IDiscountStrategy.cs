﻿using JeweleryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeweleryStore.Helpers
{
    public interface IDiscountStrategy
    {
        double GetDiscountPerc(CustomUser user);
    }
}
