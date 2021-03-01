using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeweleryStore.Models {
    public class CustomUser : IdentityUser {
        public bool IsPrivileged { get; set; }
    }
}
