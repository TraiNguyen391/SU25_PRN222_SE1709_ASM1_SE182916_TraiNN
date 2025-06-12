using SchoolMedical.Repository.TraiNN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMedical.Service.TraiNN
{
    public interface IMedicationOrderTraiNNService
    {
        Task<List<MedicationOrderTraiNn>> GetAllAsync();
        Task<int> CreateAsync(MedicationOrderTraiNn entity);
        Task<int> UpdateAsync(MedicationOrderTraiNn entity);
        //Task<MedicationOrderTraiNn> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}
