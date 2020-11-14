using Domain.Models.Entities.Identity;
using Domain.Service.Const;
using Domain.Service.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystem.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {

        
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticateController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                authClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));


                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {

            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            return Ok(new ResponseDto { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterDto model)
        {
            try
            {
                var userExists = await userManager.FindByNameAsync(model.Username);
                if (userExists != null)
                    return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto { Status = "Error", Message = "User already exists!" });

                ApplicationUser user = new ApplicationUser()
                {
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = model.Username
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                    return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto { Status = "Error", Message = "User creation failed! Please check user details and try again." });

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                if (await roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await userManager.AddToRoleAsync(user, UserRoles.Admin);
                }

                return Ok(new ResponseDto { Status = "Success", Message = "User created successfully!" });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> ChangeUserRoles(string userName, List<string> userRoles)
        {
            var user = await userManager.FindByNameAsync(userName);
            if (user != null)
            {
               var roles = await userManager.GetRolesAsync(user);
                if (roles != null && roles.Count > 0)
                {
                   await userManager.RemoveFromRolesAsync(user, roles);
                }

                await userManager.AddToRolesAsync(user, userRoles);
                return Ok(new ResponseDto { Status = "Success", Message = "User roles changed successfully!" });
            }
            return Unauthorized();
        }

        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<IActionResult> GetUserRoles(string userName)
        {

            var user = await userManager.FindByNameAsync(userName);
            if (user != null)
            {
                var userRoles = await userManager.GetRolesAsync(user);
                return Ok(userRoles);
            }
            return Unauthorized();
        }

        [Authorize]
        [HttpGet]
        public ActionResult<string> GetLoggedInUserId() 
        {
            //var  hasadmin=   this.User.Claims.Any(x => x.Type == ClaimTypes.Role && x.Value == "Admin");          
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;          
            return userId;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetLoggedInUserRoles()
        {
            var user =await userManager.FindByNameAsync(this.User.FindFirst(ClaimTypes.Name).Value);
            var userRoles =await userManager.GetRolesAsync(user);
            return Ok(userRoles);
        }
    }
}
