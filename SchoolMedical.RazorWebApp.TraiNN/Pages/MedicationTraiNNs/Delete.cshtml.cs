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
    [Authorize(Roles = "1")]
    public class DeleteModel : PageModel
    {
        private readonly IMedicationTraiNNService _medicationTraiNNService;

        public DeleteModel(IMedicationTraiNNService medicationTraiNNService)
        {
            _medicationTraiNNService = medicationTraiNNService;
        }

        [BindProperty]
        public MedicationTraiNn MedicationTraiNn { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicationtrainn = await _medicationTraiNNService.GetByIdAsync(id.Value);

            if (medicationtrainn == null)
            {
                return NotFound();
            }
            else
            {
                MedicationTraiNn = medicationtrainn;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicationtrainn = await _medicationTraiNNService.GetByIdAsync(id.Value);

            if (medicationtrainn != null)
            {
                MedicationTraiNn = medicationtrainn;
                _medicationTraiNNService.DeleteAsync(id.Value);
                //await _medicationTraiNNService.SaveChangesAsync();    //lưu sau
            }

            return RedirectToPage("./Index");
        }
    }
}
