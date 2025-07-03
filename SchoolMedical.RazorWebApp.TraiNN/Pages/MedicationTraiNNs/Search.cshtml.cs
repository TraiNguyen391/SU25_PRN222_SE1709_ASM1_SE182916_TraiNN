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
    public class SearchModel : PageModel
    {
        private readonly IMedicationTraiNNService _medicationTraiNNService;

        public SearchModel(IMedicationTraiNNService medicationTraiNNService)
        {
            _medicationTraiNNService = medicationTraiNNService;
        }

        public IList<MedicationTraiNn> MedicationTraiNn { get; set; } = new List<MedicationTraiNn>();

        // Pagination properties
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 10; // Số bản ghi mỗi trang

        public async Task OnGetAsync(int? pageNumber, int? code, int? quantity, string medicineName)
        {
            List<MedicationTraiNn> allItems;

            if (code.HasValue || quantity.HasValue || !string.IsNullOrEmpty(medicineName))
            {
                // Nếu có bất kỳ tham số tìm kiếm nào, thực hiện tìm kiếm
                allItems = await _medicationTraiNNService.SearchAsync(code ?? 0, quantity ?? 0, medicineName);
            }
            else
            {
                // Nếu không, lấy tất cả
                allItems = await _medicationTraiNNService.GetAllAsync();
            }

            CurrentPage = pageNumber ?? 1;
            int totalCount = allItems.Count;
            TotalPages = (int)Math.Ceiling(totalCount / (double)PageSize);

            MedicationTraiNn = allItems
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToList();
        }
    }
}