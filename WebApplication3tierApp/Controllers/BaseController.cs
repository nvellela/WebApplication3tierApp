using _1CommonInfrastructure.Interfaces;
using _3BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.DirectoryServices.Protocols;

namespace WebApplication3tierApp.Controllers
{

    [Authorize]
    public abstract class BaseController : ControllerBase
    {
        
        //public string GetUsername()
        //{
        //    var username = User.Identity.Name;        

        //    return username;
        //}
    }
    

    public class UserNameResolver : IUserNameResolver
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserNameResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUsername()
        {
            var username = _httpContextAccessor.HttpContext.User.Identity.Name;
            return username;
        }     

    }

   
}
