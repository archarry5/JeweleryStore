using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JeweleryStore.Helpers;
using JeweleryStore.Models;
using JeweleryStore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JeweleryStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly UserDbContext context;
        readonly IUserHelper userHelper;

        public UserController(UserDbContext context, IUserHelper userHelper) {
            this.context = context;
            this.userHelper = userHelper;
        }

        [HttpGet("IsPrivileged")]
        public IActionResult GetUserType() {
            var userId = HttpContext.User.Claims.First().Value;
            var user = context.Users.Where(u => u.Id == userId).FirstOrDefault();
            if (user == null) {
                return NotFound("User Not Found");
            } else {
                return Ok(user.IsPrivileged);
            }
        }

        [HttpGet("getDiscountPerc")]
        public IActionResult GetDiscountPerc() {
            var userId = HttpContext.User.Claims.First().Value;
            var user = context.Users.Where(u => u.Id == userId).FirstOrDefault();
            if (user == null) {
                return NotFound("User Not Found");
            } else {
                return Ok(userHelper.GetDiscountPerc(user));
            }
        }

    }
}