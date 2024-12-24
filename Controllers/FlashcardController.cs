using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartCards.DTOs.Flashcard;
using SmartCards.Models;

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

        [HttpPost]
        public IActionResult Import(List<FlashcardDTO> flashcards)
        {

            return View();
        }
    }
}
