using SchoolMedical.Repository.TraiNN;
using SchoolMedical.Repository.TraiNN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMedical.Service.TraiNN
{
    public class MedicationTraiNNService : IMedicationTraiNNService
    {
        private readonly MedicationTraiNNRepository _repository;

        public MedicationTraiNNService() => _repository ??= new MedicationTraiNNRepository();

        public async Task<List<MedicationTraiNn>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<MedicationTraiNn> GetByIdAsync(int code)
        {
            return await _repository.GetByIdAsync(code);
        }

        public async Task<List<MedicationTraiNn>> SearchAsync(int code, int amount, string bankNo)
        {
            return await _repository.SearchAsync(code, amount, bankNo);
        }

        public async Task<int> CreateAsync(MedicationTraiNn entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public async Task<int> UpdateAsync(MedicationTraiNn entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int code)
        {
            var item = await _repository.GetByIdAsync(code);

            if (item != null)
            {
                return await _repository.RemoveAsync(item);
            }

            return false;
        }
    }
}
