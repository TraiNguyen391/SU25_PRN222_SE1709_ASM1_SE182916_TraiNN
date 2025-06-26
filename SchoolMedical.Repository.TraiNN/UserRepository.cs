using Microsoft.EntityFrameworkCore;
using SchoolMedical.Repository.TraiNN.Basic;
using SchoolMedical.Repository.TraiNN.DBContext;
using SchoolMedical.Repository.TraiNN.Models;

namespace SchoolMedical.Repository.TraiNN
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository() { }

        public UserRepository(SU25_PRN222_SE1709_G1_SchoolMedicalContext context) => _context = context;

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
