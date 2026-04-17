using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidySphere.Application.DTOs;

namespace VidySphere.Application.Interfaces
{
    public interface ICourseService
    {

        Task CreateCourse(CreateCourseRequest request, long instructorId);
        Task<IEnumerable<CourseResponse>> GetCourses();

    }
}
