using Microsoft.EntityFrameworkCore;
using SchoolMedical.Repository.TraiNN.Basic;
using SchoolMedical.Repository.TraiNN.DBContext;
using SchoolMedical.Repository.TraiNN.Models;

namespace SchoolMedical.Repository.TraiNN
{
    public class MedicationOrderTraiNNRepository : GenericRepository<MedicationOrderTraiNn>
    {
        public MedicationOrderTraiNNRepository() { }

        public MedicationOrderTraiNNRepository(SU25_PRN222_SE1709_G1_SchoolMedicalContext context) => _context = context;

        public async Task<List<MedicationOrderTraiNn>> GetAllAsync()
        {
            var item = await _context.MedicationOrderTraiNns.ToListAsync();
            return item ?? new List<MedicationOrderTraiNn>();
        }
    }
}
