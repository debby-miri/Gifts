using Gifts;
using Microsoft.EntityFrameworkCore;
using Solid.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<User> SignIn(User user)
        {
            return _context.Users.FirstOrDefault(u => u.Password == user.Password && u.Mail == user.Mail);


        }
        public async Task<User> SignUp(User user)
        {
            if (_context.Users.Any(u => u.Mail == user.Mail))
            {
                return null;
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task<List<User>> GetListAsync()
        {
            return await _context.Users.Include(u => u.GiftsList).ToListAsync();
        }

        public async Task<List<Gift>> GetListOfGiftsAsync(int id)
        {
            return await _context.Gifts.Where(gift => gift.User.UserId == id).ToListAsync();
        }

        public async Task<User> UpdateAsync(int id, User user)
        {

            User user1 = _context.Users.FirstOrDefault(x => x.UserId == id);
            if (user1 != null)
            {
                user1.FirstName = user.FirstName;
                user1.LastName = user.LastName;
                user1.Password = user.Password;
                user1.Phon = user.Phon;
                user1.Mail = user.Mail;
            }
            await _context.SaveChangesAsync();
            return user1;
        }

        public async Task<string> BlockUser(int id)
        {
            var item = await GetByIdAsync(id);
            item.Status = 2;
            item.DateOfStatusChange = DateTime.Now;
            await _context.SaveChangesAsync();
            return "blocked";
        }

        public async Task<string> SuspendUser(int id)
        {
            var item = await GetByIdAsync(id);
            item.Status = 0;
            item.DateOfStatusChange = DateTime.Now;
            await _context.SaveChangesAsync();
            return "suspended";
        }

        public async Task<string> UnSuspendUser(int id)
        {
            var item = await GetByIdAsync(id);
            item.Status = 1;
            item.DateOfStatusChange = DateTime.Now;
            await _context.SaveChangesAsync();
            return "Unsuspended";
        }
    }
}
