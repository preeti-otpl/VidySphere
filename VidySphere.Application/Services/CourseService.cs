using Dapper;
using System.Data;
using VidySphere.Application.DTOs;
using VidySphere.Application.Interfaces;
using VidySphere.Domain.Entities;
using VidySphere.Domain.Interfaces;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepo;
    private readonly ITenantProvider _tenantProvider;

    public CourseService(ICourseRepository courseRepo, ITenantProvider tenantProvider)
    {
        _courseRepo = courseRepo;
        _tenantProvider = tenantProvider;
    }

    public async Task CreateCourse(CreateCourseRequest request, long instructorId)
    {
        var course = new Course
        {
            Title = request.Title,
            Description = request.Description,

            InstructorId = instructorId,
            TenantId = _tenantProvider.TenantId,

            CreatedAt = DateTime.UtcNow
        };

        await _courseRepo.AddAsync(course);
    }

    public async Task<IEnumerable<CourseResponse>> GetCourses()
    {
        var courses = await _courseRepo.GetAllAsync();

        return courses.Select(c => new CourseResponse
        {
            Id = c.Id,
            Title = c.Title
        });
    }
}