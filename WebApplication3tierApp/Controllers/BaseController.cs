using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3tierApp.Controllers
{
    [Authorize]
    public abstract class BaseController : ControllerBase
    {

    }
}
