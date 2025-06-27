using Microsoft.EntityFrameworkCore;
using SchoolMedical.Repository.TraiNN.Basic;
using SchoolMedical.Repository.TraiNN.DBContext;
using SchoolMedical.Repository.TraiNN.Models;

namespace SchoolMedical.Repository.TraiNN
{
    public class MedicationTraiNNRepository : GenericRepository<MedicationTraiNn>
    {
        public MedicationTraiNNRepository() { }

        public MedicationTraiNNRepository(SU25_PRN222_SE1709_G1_SchoolMedicalContext context) => _context = context;

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
                .Where(d =>
                    (code == 0 || d.MedicationTraiNNid == code) &&
                    (quantity == 0 || d.Quantity == quantity) &&
                    (string.IsNullOrEmpty(medicineName) || d.MedicineName.Contains(medicineName))
                ).ToListAsync();

            return item ?? new List<MedicationTraiNn>();
        }

    }
}
