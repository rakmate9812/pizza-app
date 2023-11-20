using API.Database.Models;
using Azure.Core;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User? GetByUserName(string username)
        {
            var user = _context.Users.Where(u => string.Equals(u.Username, username)).FirstOrDefault();
            return user;
        }
    }
}
