using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidySphere.Domain.Entities;
using VidySphere.Domain.Interfaces;

namespace VidySphere.Infrastructure.TestingRepository
{
    public class TestCourseRepository : ICourseRepository
    {
        // 🔥 In-memory store
        private static List<Course> _courses = new List<Course>();

        private readonly ITenantProvider _tenantProvider;

        public TestCourseRepository(ITenantProvider tenantProvider)
        {
            _tenantProvider = tenantProvider;
        }

        public Task AddAsync(Course course)
        {
            course.Id = _courses.Count + 1;
            _courses.Add(course);

            return Task.CompletedTask;
        }

        public Task<IEnumerable<Course>> GetAllAsync()
        {
            var tenantId = _tenantProvider.TenantId;

            var result = _courses
                .Where(c => c.TenantId == tenantId && c.DeletedAt == null);

            return Task.FromResult(result);
        }
    }
}
