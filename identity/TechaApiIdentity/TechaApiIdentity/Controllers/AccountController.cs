using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TechaApiIdentity.Base;
using TechaApiIdentity.Data;

namespace TechaApiIdentity
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly JwtConfig jwtConfig;
        private readonly byte[] secret;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptionsMonitor<JwtConfig> jwtConfig)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

            this.jwtConfig = jwtConfig.CurrentValue;
            this.secret = Encoding.ASCII.GetBytes(this.jwtConfig.Secret);
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel input)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await signInManager.PasswordSignInAsync(input.Username, input.Password, true, false);
                if (!loginResult.Succeeded)
                {
                    return BadRequest();
                }
                var user = await userManager.FindByNameAsync(input.Username);
                return Ok(GetTokenResponse(user));
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("SignOut")]
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return Ok();
        }


        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePassword input)
        {
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                var response = await userManager.ChangePasswordAsync(user,input.OldPassword,input.NewPassword);
                return Ok(response);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterViewModel input)
        {
            if (ModelState.IsValid)
            {
                var newUser = new ApplicationUser
                {
                    UserName = input.Email,
                    Email = input.Email,
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    EmailConfirmed = true,
                    TwoFactorEnabled = false,
                    NationalIdNumber = input.NationalIdNumber
                };

                var registerUser = await userManager.CreateAsync(newUser, input.Password);
                if (registerUser.Succeeded)
                {
                    await signInManager.SignInAsync(newUser, isPersistent: false);
                    var user = await userManager.FindByNameAsync(newUser.UserName);

                    return Ok(GetTokenResponse(user));
                }
                AddErrors(registerUser);
            }
            return BadRequest(ModelState);

        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return userManager.GetUserAsync(HttpContext.User);
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var err in result.Errors)
            {
                ModelState.AddModelError("error", err.Description);
            }
        }
        private JwtTokenResult GetTokenResponse(ApplicationUser user)
        {
            var token = GenerateAccessToken(user);
            JwtTokenResult result = new JwtTokenResult
            {
                AccessToken = token,
                ExpireInSeconds = jwtConfig.AccessTokenExpiration * 60,   // as second
                UserId = user.Id
            };
            return result;
        }

        private string GenerateAccessToken(ApplicationUser account)
        {
            // Get claim value
            Claim[] claims = GetClaim(account);

            var shouldAddAudienceClaim = string.IsNullOrWhiteSpace(claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);

            var jwtToken = new JwtSecurityToken(
                jwtConfig.Issuer,
                shouldAddAudienceClaim ? jwtConfig.Audience : string.Empty,
                claims,
                expires: DateTime.Now.AddMinutes(jwtConfig.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return accessToken;
        }
        private static Claim[] GetClaim(ApplicationUser account)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                new Claim(ClaimTypes.Name, account.UserName),
                new Claim(ClaimTypes.Email, account.Email),
                new Claim("AccountId", account.Id.ToString()),
            };

            return claims;
        }
    }
}