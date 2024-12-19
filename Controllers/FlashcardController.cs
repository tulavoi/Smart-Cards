using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SmartCards.Controllers
{
    [Authorize]
    public class FlashcardController : Controller 
    {
        public FlashcardController()
        {
            
        }

        public IActionResult Import()
        {
            return View();
        }
    }
}
