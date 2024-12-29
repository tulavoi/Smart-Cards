using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartCards.DTOs.Flashcard;
using SmartCards.Helpers;
using SmartCards.Interfaces;

namespace SmartCards.Controllers
{
	[Authorize]
	public class CourseController : Controller
	{
		private readonly IPermissionRepository _permissionRepo;
		private readonly ILanguageRepository _languageRepo;

        public CourseController(IPermissionRepository permissionRepo,
            ILanguageRepository languageRepo)
        {
            _permissionRepo = permissionRepo;
            _languageRepo = languageRepo;
        }

        //[Route("/create-course")]
		public async Task<IActionResult> Create()
		{
            ViewBag.EditPermissions = await _permissionRepo.GetAllAsync(new PermissionQueryObject { IsEdit = true });
            ViewBag.ViewPermissions = await _permissionRepo.GetAllAsync(new PermissionQueryObject { IsEdit = false });
			ViewBag.Languages = await _languageRepo.GetAllAsync(new LanguageQueryObject { SortBy = "Name" });

			return View();
		}

		// Trả về Html của PartialView
		[HttpGet]
		public async Task<IActionResult> GetMenuLanguagesPartial([FromRoute] string inputType) 
		{
			ViewBag.Languages = await _languageRepo.GetAllAsync(new LanguageQueryObject { SortBy = "Name" });
			var model = new { InputType = inputType };
			return PartialView("~/Views/Course/ViewPartials/_MenuLanguagesPartial.cshtml", model);
        }

        // Trả về Html của PartialView
        [HttpGet]
        public async Task<IActionResult> GetTermDefinitionPartial([FromRoute] string inputType)
        {
            ViewBag.Languages = await _languageRepo.GetAllAsync(new LanguageQueryObject { SortBy = "Name" });
            var model = new { InputType = inputType };
            return PartialView("~/Views/Course/ViewPartials/_MenuLanguagesPartial.cshtml", model);
        }
    }
}
