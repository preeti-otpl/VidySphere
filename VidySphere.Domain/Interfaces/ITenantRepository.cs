using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidySphere.Domain.Entities;

namespace VidySphere.Domain.Interfaces
{
    public interface ITenantRepository
    {
        Task<Tenant?> GetByIdAsync(int id);
        Task AddAsync(Tenant tenant);
    }
}
