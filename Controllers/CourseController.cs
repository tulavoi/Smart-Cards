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

        [Route("/create-course")]
		public async Task<IActionResult> Create()
		{
            ViewBag.EditPermissions = await _permissionRepo.GetAllAsync(new PermissionQueryObject { IsEdit = true });
            ViewBag.ViewPermissions = await _permissionRepo.GetAllAsync(new PermissionQueryObject { IsEdit = false });
			ViewBag.Languages = await _languageRepo.GetAllAsync(new LanguageQueryObject { SortBy = "Name" });

			return View();
		}
	}
}
