using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TalabatG02.APIs.Dtos;
using TalabatG02.APIs.Errors;
using TalabatG02.APIs.Extentions;
using TalabatG02.Core.Entities.Identity;
using TalabatG02.Core.Services;

namespace TalabatG02.APIs.Controllers
{

    public class AccountController : ApiBaseController
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ITokenServices tokenServices;
        private readonly IMapper mapper;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            ITokenServices tokenServices, IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenServices = tokenServices;
            this.mapper = mapper;
        }
        [HttpPost("login")] //{{baseurl}}api/Account/login
        public async Task<ActionResult<UserDto>> Login(LoginDto model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user is null) return Unauthorized(new ApiErrorResponse(401));
            var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded) return Unauthorized(new ApiErrorResponse(401));
            return Ok(new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await tokenServices.CreateTokenAsync(user, userManager)

            });
        }

        [HttpPost("Register")] //{{baseurl}}api/Account/Register
        public async Task<ActionResult<UserDto>> Register(RegisterDto model)
        {
            if (CheckEmailExsist(model.Email).Result.Value)
                return BadRequest(new ApiValidationErrorResponse() { Errors = new string[] { "This Email Is Already Exist" } });
            var user = new AppUser()
            {
                DisplayName = model.DisplayName,
                Email = model.Email,
                UserName = model.Email.Split('@')[0],
                PhoneNumber = model.PhoneNumber
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded) return BadRequest(new ApiErrorResponse(400));
            return Ok(new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await tokenServices.CreateTokenAsync(user, userManager)

            });
        }
        [Authorize]
        [HttpGet("currentuser")]//{{baseurl}}api/Account/currentuser
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await userManager.FindByEmailAsync(email);
            return Ok(new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await tokenServices.CreateTokenAsync(user, userManager)
            });
        }
        [Authorize]
        [HttpGet("address")]//{{baseurl}}api/Account/address
        public async Task<ActionResult<AdressDto>> GetUserAddress()
        {
            var user = await userManager.FindUserWithAdressByEmailAsync(User);
            var address = mapper.Map<Address, AdressDto>(user.Address);
            return Ok(address);

        }
        [Authorize]
        [HttpPut("address")]
        public async Task<ActionResult<AdressDto>> UpdateUserAddress(AdressDto Updatedadress)
        {
            var address = mapper.Map<AdressDto, Address>(Updatedadress);
            var user = await userManager.FindUserWithAdressByEmailAsync(User);
            address.Id = user.Address.Id;
            user.Address = address;
            var Result = await userManager.UpdateAsync(user);
            if (!Result.Succeeded) return BadRequest(new ApiErrorResponse(400));
            return Ok(Updatedadress);
        }
        [HttpGet("checkemail")]
        public async Task<ActionResult<bool>> CheckEmailExsist(string email)
        {
            return await userManager.FindByEmailAsync(email) is not null;

        }
    }
}
