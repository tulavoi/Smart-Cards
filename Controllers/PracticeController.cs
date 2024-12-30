using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartCards.DTOs.Flashcard;
using SmartCards.Helpers;
using SmartCards.Interfaces;

namespace SmartCards.Controllers
{
	[Authorize]
	public class PracticeController : Controller
	{
		private readonly IPermissionRepository _permissionRepo;
		private readonly ILanguageRepository _languageRepo;

        public PracticeController(IPermissionRepository permissionRepo,
            ILanguageRepository languageRepo)
        {
            _permissionRepo = permissionRepo;
            _languageRepo = languageRepo;
        }

		public async Task<IActionResult> Index()
		{
            
			return View();
		}
    }
}
