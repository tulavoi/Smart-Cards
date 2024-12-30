using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCards.DTOs.Course;
using SmartCards.DTOs.Flashcard;
using SmartCards.Helpers;
using SmartCards.Interfaces;
using SmartCards.Mappers;
using SmartCards.Models;

namespace SmartCards.Controllers
{
	[Authorize]
	public class CourseController : BaseController
	{
		private readonly IPermissionRepository _permissionRepo;
		private readonly ILanguageRepository _languageRepo;
		private readonly ICourseRepository _courseRepo;

        public CourseController(IPermissionRepository permissionRepo,
            ILanguageRepository languageRepo, ICourseRepository courseRepo)
        {
            _permissionRepo = permissionRepo;
            _languageRepo = languageRepo;
            _courseRepo = courseRepo;
        }

        //[Route("/create-course")]
        public async Task<IActionResult> Create()
		{
            ViewBag.EditPermissions = await _permissionRepo.GetAllAsync(new PermissionQueryObject { IsEdit = true });
            ViewBag.ViewPermissions = await _permissionRepo.GetAllAsync(new PermissionQueryObject { IsEdit = false });
			ViewBag.Languages = await _languageRepo.GetAllAsync(new LanguageQueryObject { SortBy = "Name" });

			return View();
		}

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseRequestDTO courseDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var course = courseDTO.ToCourseFromCreateDTO(this.UserId);
            await _courseRepo.CreateAsync(course, courseDTO.ViewPermissionId, courseDTO.EditPermissionId);

            //return RedirectToAction("Index", "Home");
            return CreatedAtAction(nameof(GetById), new { id = course.Id }, course);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var course = _courseRepo.GetByIdAsync(id);
            if (course == null) return NotFound();
            return Ok(course);
        }

        // Trả về Html của PartialView
        [HttpGet]
        public async Task<IActionResult> GetTermDefinitionPartial([FromQuery] int count, [FromQuery] string termValue, 
            [FromQuery] string defiValue, [FromQuery] int termLanguageId, [FromQuery] int defiLanguageId)
        {
            ViewBag.Languages = await _languageRepo.GetAllAsync(new LanguageQueryObject { SortBy = "Name" });
            var model = new { 
                count = count, 
                termValue = termValue, 
                defiValue = defiValue, 
                termLanguageId = termLanguageId, 
                defiLanguageId = defiLanguageId,
            };
            return PartialView("~/Views/Course/ViewPartials/_TermDefinitionPartial.cshtml", model);
        }
    }
}
