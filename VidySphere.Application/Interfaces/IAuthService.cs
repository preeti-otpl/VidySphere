using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidySphere.Domain.Entities;

namespace VidySphere.Application.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(User user);
    }
}
