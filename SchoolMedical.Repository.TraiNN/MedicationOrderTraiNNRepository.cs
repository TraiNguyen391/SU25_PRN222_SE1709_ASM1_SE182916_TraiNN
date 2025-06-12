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
    public class MedicationOrderTraiNNRepository : GenericRepository<MedicationOrderTraiNn>
    {
        public MedicationOrderTraiNNRepository() { }

        public MedicationOrderTraiNNRepository(Medication context) => _context = context;

        public async Task<List<MedicationOrderTraiNn>> GetAllAsync()
        {
            var item = await _context.MedicationOrderTraiNns.ToListAsync();
            return item ?? new List<MedicationOrderTraiNn>();
        }
    }
}
