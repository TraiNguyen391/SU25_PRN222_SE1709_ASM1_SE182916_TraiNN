using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolMedical.Repository.TraiNN.DBContext;
using SchoolMedical.Repository.TraiNN.Models;
using SchoolMedical.Service.TraiNN;

namespace SchoolMedical.RazorWebApp.TraiNN.Pages.MedicationTraiNns
{
    [Authorize(Roles = "1, 2")]
    public class IndexModel : PageModel
    {
        //private readonly SchoolMedical.Repository.TraiNN.DBContext.zPaymentContext _context;
        private readonly IMedicationTraiNNService _medicationTraiNNService;

        public IndexModel(IMedicationTraiNNService medicationTraiNNService)
        {
            _medicationTraiNNService = medicationTraiNNService;
        }

        public IList<MedicationTraiNn> MedicationTraiNn { get;set; } = default!;

        public async Task OnGetAsync(int? code, int? quantity, string medicineName)
        {
            if (code.HasValue || quantity.HasValue || !string.IsNullOrEmpty(medicineName))
            {
                MedicationTraiNn = await _medicationTraiNNService.SearchAsync(
                    code ?? 0,
                    quantity ?? 0,
                    medicineName ?? string.Empty
                );
            }
            else
            {
                MedicationTraiNn = await _medicationTraiNNService.GetAllAsync();
            }
        }
    }
}
