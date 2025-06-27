using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMedical.Repository.TraiNN.Models;
using SchoolMedical.Service.TraiNN;

namespace SchoolMedical.RazorWebApp.TraiNN.Pages.MedicationTraiNns
{
    [Authorize(Roles = "1, 2")]
    public class DetailsModel : PageModel
    {
        private readonly IMedicationTraiNNService _medicationTraiNNService;

        public DetailsModel(IMedicationTraiNNService medicationTraiNNService)
        {
            _medicationTraiNNService = medicationTraiNNService;
        }

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
    }
}
