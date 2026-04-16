using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidySphere.Application.DTOs;
using VidySphere.Application.Interfaces;
using VidySphere.Domain.Entities;
using VidySphere.Domain.Interfaces;

namespace VidySphere.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(IUserRepository userRepo, IPasswordHasher passwordHasher)
        {
            _userRepo = userRepo;
            _passwordHasher = passwordHasher;
        }

        // ✅ REGISTER
        public async Task Register(RegisterRequest request)
        {
            var existingUser = await _userRepo.GetByEmailAsync(request.Email);

            if (existingUser != null)
                throw new Exception("User already exists");

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,

                PasswordHash = _passwordHasher.Hash(request.Password),

                TenantId = request.TenantId,
                Role = "Student",
                ProfileImageUrl = "",
                RowVersion = [],
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                IsEmailVerified = false,
                FailedLoginAttempts = 0
            };

            await _userRepo.AddAsync(user);
        }

        // ✅ LOGIN
        public async Task<User?> Login(string email, string password)
        {
            var user = await _userRepo.GetByEmailAsync(email);

            if (user == null)
                return null;

            // 🔒 Soft delete check
            if (user.DeletedAt != null)
                throw new Exception("User is deleted");

            // 🔒 Active check
            if (!user.IsActive)
                throw new Exception("User is inactive");

            // 🔒 Password validation
            var isValid = _passwordHasher.Verify(password, user.PasswordHash);

            if (!isValid)
            {
                user.FailedLoginAttempts++;
                return null;
            }

            // ✅ Reset attempts
            user.FailedLoginAttempts = 0;
            user.LastLoginAt = DateTime.UtcNow;

            await _userRepo.UpdateAsync(user);

            return user;
        }
    }
}
