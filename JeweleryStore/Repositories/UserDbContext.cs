using JeweleryStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeweleryStore.Repositories {
    public class UserDbContext : IdentityDbContext<CustomUser> {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
    }
}
