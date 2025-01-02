using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartCards.DTOs.Flashcard;
using SmartCards.Helpers;
using SmartCards.Interfaces;

namespace SmartCards.Controllers
{
	[Authorize]
	[Route("/practice")]
	public class PracticeController : Controller
	{
		[HttpGet("{slug}")]
		public async Task<IActionResult> Index([FromRoute] string slug)
		{
            
			return View();
		}
    }
}
