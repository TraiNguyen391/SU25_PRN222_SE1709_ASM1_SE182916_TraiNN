using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolMedical.Repository.TraiNN.Models;
using SchoolMedical.Service.TraiNN;

namespace SchoolMedical.RazorWebApp.TraiNN.Pages.MedicationTraiNns
{
    [Authorize(Roles = "1,3")]
    public class CreateModel : PageModel
    {
        private readonly IMedicationTraiNNService _medicationTraiNNService;
        private readonly IMedicationOrderTraiNNService _medicationOrderTraiNNService;

        public CreateModel(IMedicationTraiNNService medicationTraiNNService, IMedicationOrderTraiNNService medicationOrderTraiNN)
        {
            _medicationTraiNNService = medicationTraiNNService;
            _medicationOrderTraiNNService = medicationOrderTraiNN;
        }

        public async Task<IActionResult> OnGet()
        {
            var medication = await _medicationTraiNNService.GetAllAsync();
            var medicationOrder = await _medicationOrderTraiNNService.GetAllAsync();

            //ViewData["DonguiId"] = new SelectList(medication, "DonguiId", "DonguiId");
            ViewData["DonguiId"] = new SelectList(medicationOrder, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public MedicationTraiNn MedicationTraiNn { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            MedicationTraiNn.MedicationTraiNNid = 0;

            MedicationTraiNn.Status = true; // Default status
            MedicationTraiNn.ReceiveDate = DateTime.Now; // Default receive date

            //if (MedicationTraiNn.MedicineName == null || MedicationTraiNn.MedicineName.Trim().Length == 0)
            //{
            //    MedicationTraiNn.DonguiId = 1; // Default value if empty
            //    MedicationTraiNn.MedicineName = "Test data"; // Default value if empty
            //    MedicationTraiNn.Quantity = 1; // Default quantity
            //    MedicationTraiNn.Unit = "mg"; // Default unit
            //    MedicationTraiNn.Type = "Test type"; // Default type
            //    MedicationTraiNn.ParentNote = "Test parent note"; // Default parent note
            //    MedicationTraiNn.NurseNote = "Test nurse note"; // Default nurse note
            //    MedicationTraiNn.ReceiveDate = DateTime.Now;
            //    MedicationTraiNn.Status = true;
            //}


            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _medicationTraiNNService.CreateAsync(MedicationTraiNn);

            return RedirectToPage("./Index");
        }
    }
}
