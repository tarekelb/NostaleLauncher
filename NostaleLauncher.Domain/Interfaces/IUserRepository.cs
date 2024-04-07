using NostaleLauncher.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostaleLauncher.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> FindByUsernameAsync(string username);
        Task CreateUserAsync(User user);
    }
}
