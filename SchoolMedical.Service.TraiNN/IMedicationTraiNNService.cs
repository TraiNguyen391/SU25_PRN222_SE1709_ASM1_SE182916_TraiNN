using SchoolMedical.Repository.TraiNN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMedical.Service.TraiNN
{
    public interface IMedicationTraiNNService
    {
        Task<List<MedicationTraiNn>> GetAllAsync();
        Task<MedicationTraiNn> GetByIdAsync(int code);
        Task<List<MedicationTraiNn>> SearchAsync(int code, int amount, string bankNo);
        Task<int> CreateAsync(MedicationTraiNn entity);
        Task<int> UpdateAsync(MedicationTraiNn entity);
        Task<bool> DeleteAsync(int code);

    }
}
