using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _appDbContext;

        public UserService(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<User> GetUser()
        {
            return await _appDbContext.Users.OrderByDescending(u => u.Orders.Count()).FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetUsers()
        {
            return await _appDbContext.Users.Where(u => u.Status == Enums.UserStatus.Inactive).ToListAsync();
        }
    }
}
