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
    [Route("/course")]
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

        [Route("/create-course")]
        public async Task<IActionResult> Create()
		{
            await this.SetViewBagForCreatCourse();
			return View();
		}

        [HttpPost("/create-course")]
        public async Task<IActionResult> Create(CreateCourseRequestDTO courseDTO)
        {
            // Kiểm tra và trả vê lỗi nếu có
            string errorMessage = _courseRepo.GetErrorMessage(courseDTO);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                TempData["ErrorMessage"] = errorMessage;
                await this.SetViewBagForCreatCourse();
                return View(courseDTO);
            }

            // Tạo học phần mới
            var course = courseDTO.ToCourseFromCreateDTO(this.UserId);
            await _courseRepo.CreateAsync(course, courseDTO.ViewPermissionId, courseDTO.EditPermissionId);

            return CreatedAtAction(nameof(GetById), new { id = course.Id }, course.ToCourseDTO());
        }

        private async Task SetViewBagForCreatCourse()
        {
            ViewBag.EditPermissions = await _permissionRepo.GetAllAsync(new PermissionQueryObject { IsEdit = true });
            ViewBag.ViewPermissions = await _permissionRepo.GetAllAsync(new PermissionQueryObject { IsEdit = false });
            ViewBag.Languages = await _languageRepo.GetAllAsync(new LanguageQueryObject { SortBy = "Name" });
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var course = await _courseRepo.GetByIdAsync(id);
            if (course == null) return NotFound();
            return Ok(course.ToCourseDTO());
        }

        // Trả về Html của PartialView
        [HttpGet]
        [Route("GetTermDefinitionPartial")]
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
