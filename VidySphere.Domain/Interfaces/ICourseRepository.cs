using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidySphere.Domain.Entities;

namespace VidySphere.Domain.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllAsync(int tenantId);
        Task<Course?> GetByIdAsync(int id, int tenantId);
        Task AddAsync(Course course);
    }
}
