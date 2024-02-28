using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleConfigurator02.DbRepos;

namespace WebApp11.Repository
{
    public class UserRepositoryImpl : IUserRepository
    {
        private readonly ScottDbContext _context;

        public UserRepositoryImpl(ScottDbContext context)
        {
            _context = context;
        }

     
        public async Task<ActionResult<User>> Add(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> ValidateUser(string Username, string Password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == Username && u.Password == Password);
            return user != null;
        }

    }
}
