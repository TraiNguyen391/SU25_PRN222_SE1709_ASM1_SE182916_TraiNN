using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using SchoolMedical.Repository.TraiNN.Models;
using SchoolMedical.Service.TraiNN;

namespace SchoolMedical.RazorWebApp.TraiNN.Hubs
{
    public class SchoolMedicalHub : Hub
    {
        private readonly IMedicationTraiNNService _medicationTraiNNService;

        public SchoolMedicalHub(IMedicationTraiNNService medicationTraiNNService)
        {
            _medicationTraiNNService = medicationTraiNNService;
        }

        public async Task HubDelete_SchoolMedical(string schoolMedicalId)
        {
            await Clients.All.SendAsync("ReceiveDelete_SchoolMedical", schoolMedicalId);

            await _medicationTraiNNService.DeleteAsync(int.Parse(schoolMedicalId));
        }

        public async Task HubCreate_SchoolMedical(string schoolMedicalId)
        {
            var item = JsonConvert.DeserializeObject<MedicationTraiNn>(schoolMedicalId);

            item.Status = true; // Default status
            item.ReceiveDate = DateTime.Now; // Default receive date

            //if (item.MedicineName == null || item.MedicineName.Trim().Length == 0)
            //{
            //    item.DonguiId = 1; // Default value if empty
            //    item.MedicineName = "Test data"; // Default value if empty
            //    item.Quantity = 1; // Default quantity
            //    item.Unit = "mg"; // Default unit
            //    item.Type = "Test type"; // Default type
            //    item.ParentNote = "Test parent note"; // Default parent note
            //    item.NurseNote = "Test nurse note"; // Default nurse note
            //    item.ReceiveDate = DateTime.Now;
            //    item.Status = true;
            //}

            await Clients.All.SendAsync("ReceiveCreate_SchoolMedical", item);

            await _medicationTraiNNService.CreateAsync(item);
        }

        public async Task HubUpdate_SchoolMedical(string schoolMedicalId)
        {
            var item = JsonConvert.DeserializeObject<MedicationTraiNn>(schoolMedicalId);

            await Clients.All.SendAsync("ReceiveUpdate_SchoolMedical", item);

            await _medicationTraiNNService.UpdateAsync(item);
        }

    }
}
