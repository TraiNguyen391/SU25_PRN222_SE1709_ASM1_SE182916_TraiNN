using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolMedical.Repository.TraiNN.DBContext;
using SchoolMedical.Repository.TraiNN.Models;
using SchoolMedical.Service.TraiNN;

namespace SchoolMedical.RazorWebApp.TraiNN.Pages.MedicationTraiNns
{
    [Authorize(Roles = "1")]
    public class EditModel : PageModel
    {
        private readonly IMedicationTraiNNService _medicationTraiNNService;
        private readonly IMedicationOrderTraiNNService _medicationOrderTraiNNService; //thêm bảng phụ

        public EditModel(IMedicationTraiNNService medicationTraiNNService, IMedicationOrderTraiNNService medicationOrderTraiNNService) //cho thêm bảng phụ
        {
            _medicationTraiNNService = medicationTraiNNService;
            _medicationOrderTraiNNService = medicationOrderTraiNNService;
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
            //thêm bảng phụ

            if (medicationtrainn == null)
            {
                return NotFound();
            }

            MedicationTraiNn = medicationtrainn;

            var categoryMedication = await _medicationTraiNNService.GetAllAsync();
            var categoryMedicationOrder = await _medicationOrderTraiNNService.GetAllAsync();

            ViewData["DonguiId"] = new SelectList(categoryMedicationOrder, "Id", "Id");
            //ViewData["DonguiId"] = new SelectList(categoryMedication, "DonguiId", "DonguiId");
            //thêm bảng phụ

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_medicationTraiNNService.Attach(MedicationTraiNn).State = EntityState.Modified; //bỏ, ko cần

            try
            {
                //await _medicationTraiNNService.SaveChangesAsync();
                await _medicationTraiNNService.UpdateAsync(MedicationTraiNn);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicationTraiNnExists(MedicationTraiNn.MedicationTraiNNid))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MedicationTraiNnExists(int id)
        {
            //return _medicationTraiNNService.MedicationTraiNns.Any(e => e.MedicationTraiNNid == id);

            var medication = _medicationTraiNNService.GetByIdAsync(id);

            return medication != null && MedicationTraiNn.DonguiId == id;
        }
    }
}
