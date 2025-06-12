using SchoolMedical.Repository.TraiNN;
using SchoolMedical.Repository.TraiNN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMedical.Service.TraiNN
{
    public class MedicationOrderTraiNNService : IMedicationOrderTraiNNService
    {
        private readonly MedicationOrderTraiNNRepository _repository;

        public MedicationOrderTraiNNService() => _repository ??= new MedicationOrderTraiNNRepository();

        public async Task<int> CreateAsync(MedicationOrderTraiNn entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = _repository.GetByIdAsync(id);
            if (item != null)
            {
                return await _repository.RemoveAsync(item.Result);
            }
            return await Task.FromResult(false);
        }

        public async Task<List<MedicationOrderTraiNn>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<int> UpdateAsync(MedicationOrderTraiNn entity)
        {
            var existingEntity = _repository.GetByIdAsync(entity.Id);
            if (existingEntity != null)
            {
                return await _repository.UpdateAsync(entity);
            }
            return await Task.FromResult(0);
        }
    }
}
