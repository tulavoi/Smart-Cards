using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SmartCards.Controllers
{
    public class BaseController : Controller
    {
        protected string UserId
        {
            get
            {
                return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
            }
        }
    }
}
