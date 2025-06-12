using Microsoft.EntityFrameworkCore;
using SchoolMedical.Repository.TraiNN.Basic;
using SchoolMedical.Repository.TraiNN.DBContext;
using SchoolMedical.Repository.TraiNN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMedical.Repository.TraiNN
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository() { }

        public UserRepository(Medication context) => _context = context;

        public async Task<SystemUserAccount> GetUserAccount(string username, string password)
        {
            return await _context.SystemUserAccounts.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password && u.IsActive == true);
        }

        //public async Task<User> GetUserAccountAsync(string username, string password)
        //{
        //    return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username && u.UserHashPassword == password);
        //}

    }
}
