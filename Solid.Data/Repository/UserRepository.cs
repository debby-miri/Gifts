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
            foreach (var u in _context.Users)
            {
                if ( u.Password == user.Password&&u.Mail==user.Mail)
                    return u;
            }
        
            return null;
        }
        public async Task<User> SignUp(User user)
        {
            foreach (var u in _context.Users)
            {
                if (u.Password == user.Password && u.Mail == user.Mail)
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
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task<List<User>> GetListAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<List<Gift>> GetListOfGiftsAsync(int id)
        {
            return await _context.Gifts.Where(gift => gift.User.UserId == id).ToListAsync();
        }

        public async Task<User> UpdateAsync(int id, User user)
        {
            User user1 = null;

            foreach (var item in _context.Users)
            {
                if (item.UserId == id)
                {
                    item.FirstName = user.FirstName;
                    item.LastName = user.LastName;
                    item.Password = user.Password;
                    item.Phon = user.Phon;
                    item.Mail = user.Mail;
                    user1 = item;
                }

            }
            await _context.SaveChangesAsync();
            return user1;
        }

        public async Task<string> BlockUser(int id)
        {
            foreach (var item in _context.Users)
            {
                if (item.UserId == id)
                {
                    item.Status = 2;
                    item.DateOfStatusChange = DateTime.Now;
                }
            }
            await _context.SaveChangesAsync();
            return "blocked";
        }

        public async Task<string> SuspendUser(int id)
        {
            foreach (var item in _context.Users)
            {
                if (item.UserId == id)
                {
                    item.Status = 0;
                    item.DateOfStatusChange = DateTime.Now;
                }
            }
            await _context.SaveChangesAsync();
            return "suspended";
        }

        public async Task<string> UnSuspendUser(int id)
        {
            foreach (var item in _context.Users)
            {
                if (item.UserId == id)
                {
                    item.Status = 1;
                    item.DateOfStatusChange = DateTime.Now;
                }
            }
            await _context.SaveChangesAsync();
            return "Unsuspended";
        }
    }
}
