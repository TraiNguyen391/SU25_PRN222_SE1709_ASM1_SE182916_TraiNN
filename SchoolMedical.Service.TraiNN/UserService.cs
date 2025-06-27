using SchoolMedical.Repository.TraiNN;
using SchoolMedical.Repository.TraiNN.Models;

namespace SchoolMedical.Service.TraiNN
{
    public class UserService
    {
        private readonly UserRepository _repository;
        public UserService() => _repository = new UserRepository();

        public async Task<SystemUserAccount> GetUserAsync (string username, string password)
        {
            return await _repository.GetUserAccount(username, password);
        }
    }
}
