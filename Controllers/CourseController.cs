using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartCards.DTOs.Flashcard;

namespace SmartCards.Controllers
{
	[Authorize]
	public class CourseController : Controller
	{
		//[Route("/create-course")]
		public IActionResult Create(List<FlashcardDTO>? flashcardsDTO)
		{
			if (flashcardsDTO != null && flashcardsDTO.Count != 0)
			{
				foreach (var item in flashcardsDTO)
				{
					Console.WriteLine(item.Term);
				}
			}

			return View();
		}
	}
}
