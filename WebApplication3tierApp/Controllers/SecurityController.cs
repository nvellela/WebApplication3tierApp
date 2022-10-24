using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3tierApp.Models;

namespace WebApplication3tierApp.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : BaseController
    {
        private readonly IUserAuthService _userAuthService;

        public AuthController(IUserAuthService userAuthService)
        {
            _userAuthService = userAuthService;
        }

        [Route("GetUserAuthorisation"), HttpGet]
        [Produces("application/json")]
        public async Task<UserAuthDto?> GetUserAuthorisation()
        {
            //"LAPTOP-325PDDR9\\asus"
            //var result = await _userAuthService.GetCurrentUserAuth();
            //return result?.ToUserAuthDto();
            return null;
        }        
    }
}
