using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JeweleryStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace JeweleryStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        readonly UserManager<CustomUser> userManager;
        readonly SignInManager<CustomUser> signInManager;
        readonly IConfiguration configuration;
        public AccountController(UserManager<CustomUser> userManager, SignInManager<CustomUser> signInManager, IConfiguration config) {
            this.userManager = userManager;
            this.signInManager = signInManager;
            configuration = config;
        }

        [HttpPost("login")] 
        public async Task<IActionResult> Login([FromBody] Credentials credentials) {
            var result = await signInManager.PasswordSignInAsync(credentials.UserName, credentials.Password, false, false);

            if (!result.Succeeded)
                return BadRequest();

            var user = await userManager.FindByNameAsync(credentials.UserName);

            return Ok(new {
                token = CreateToken(user)
            });
        }

        string CreateToken(IdentityUser user) {
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id)
            };

            var signingKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration.GetValue<string>("SecretPhrase"))
                );
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(signingCredentials: signingCredentials, claims: claims);
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}