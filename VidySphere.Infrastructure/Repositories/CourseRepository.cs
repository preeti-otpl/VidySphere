using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidySphere.Domain.Entities;
using VidySphere.Domain.Interfaces;

namespace VidySphere.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IDbConnection _connection;
        private readonly ITenantProvider _tenantProvider;

        public CourseRepository(IDbConnection connection, ITenantProvider tenantProvider)
        {
            _connection = connection;
            _tenantProvider = tenantProvider;
        }

        public async Task AddAsync(Course course)
        {
            var query = @"INSERT INTO Courses 
                      (Title, Description, InstructorId, TenantId, CreatedAt)
                      VALUES 
                      (@Title, @Description, @InstructorId, @TenantId, @CreatedAt)";

            await _connection.ExecuteAsync(query, course);
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            var tenantId = _tenantProvider.TenantId;

            var query = @"SELECT * FROM Courses 
                      WHERE TenantId = @TenantId AND DeletedAt IS NULL";

            return await _connection.QueryAsync<Course>(query, new { TenantId = tenantId });
        }
    }
}
