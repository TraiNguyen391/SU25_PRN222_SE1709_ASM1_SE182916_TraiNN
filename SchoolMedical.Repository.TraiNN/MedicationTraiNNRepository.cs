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
    public class MedicationTraiNNRepository : GenericRepository<MedicationTraiNn>
    {
        public MedicationTraiNNRepository() { }

        public MedicationTraiNNRepository(Medication context) => _context = context;

        public async Task<List<MedicationTraiNn>> GetAllAsync()
        {
            var item = await _context.MedicationTraiNns.Include(c => c.Dongui).ToListAsync();
            //Include cái cần dùng (bảng phụ)
            return item ?? new List<MedicationTraiNn>();
        }

        public async Task<MedicationTraiNn> GetByIdAsync(int code) //Guid - id của bảng chính
        {
            var item = await _context.MedicationTraiNns
                .Include(d => d.Dongui)
                .ThenInclude(u => u.Nurse) // Bảng phụ lấy tên y tá
                .Include(d => d.Dongui)
                .ThenInclude(u => u.Parent) // Bảng phụ lấy tên phụ huynh
                .Include(d => d.Dongui)
                .ThenInclude(u => u.Student) // Bảng phụ lấy tên học sinh
                .FirstOrDefaultAsync(d => d.MedicationTraiNNid == code);

            return item ?? new MedicationTraiNn();
        }

        public async Task<List<MedicationTraiNn>> SearchAsync(int code, int quantity, string medicineName)
        {
            //search theo ID, name, số

            var item = await _context.MedicationTraiNns.Include(d => d.Dongui)
                .Where(d => d.MedicationTraiNNid == code || code == null || code == 0 //search theo ID 
                    && (d.Quantity == quantity || quantity == null || quantity == 0)  //search theo số
                    && (d.MedicineName.Contains(medicineName) || string.IsNullOrEmpty(medicineName)) //string
                ).ToListAsync();

            return item ?? new List<MedicationTraiNn>();
        }

    }
}
