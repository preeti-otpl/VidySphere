using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidySphere.Application.DTOs;
using VidySphere.Domain.Entities;

namespace VidySphere.Application.Interfaces
{
    public interface IUserService
    {
        Task Register(RegisterRequest request);
        Task<User?> Login(string email, string password);
    }
}
