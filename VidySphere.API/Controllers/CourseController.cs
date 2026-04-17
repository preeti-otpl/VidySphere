using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VidySphere.Application.DTOs;
using VidySphere.Application.Interfaces;

namespace VidySphere.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // 🔥 All APIs secured
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // ✅ Only Instructor/Admin can create
        [HttpPost]
        [Authorize(Roles = "Instructor,Admin")]
        public async Task<IActionResult> CreateCourse(CreateCourseRequest request)
        {
            var instructorId = Convert.ToInt64(
                User.FindFirst("UserId")?.Value);

            await _courseService.CreateCourse(request, instructorId);

            return Ok("Course created");
        }

        // ✅ All authenticated users can view
        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _courseService.GetCourses();

            return Ok(courses);
        }
    }
}
