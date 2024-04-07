using System.Diagnostics;
using NostaleLauncher.Domain.Entities;
using NostaleLauncher.Domain.Interfaces;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


namespace NostaleLauncher.API.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<AuthService> _logger;

        public AuthService(IUserRepository userRepository, ILogger<AuthService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<bool> ValidateUserAsync(string username, string password)
        {
            var user = await _userRepository.FindByUsernameAsync(username);
            _logger.LogInformation("Attempting to validate user: {Username}", username);
            if (user == null)
            {
                _logger.LogWarning("User not found: {Username}", username);
                return false;
            }

            if (user.Password != password)
            {
                _logger.LogWarning("Invalid password for user: {Username}", username);
                return false;
            }
            _logger.LogInformation("User validated: {Username}", username);
            return true;
        }

        public async Task<bool> RegisterUserAsync(string username, string password)
        {
            var existingUser = await _userRepository.FindByUsernameAsync(username);
            if (existingUser != null)
                return false;

            var user = new User { Username = username, Password = password };

            await _userRepository.CreateUserAsync(user);
            return true;
        }
    }
}