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
            item.ReceiveDate = DateTime.Now;

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
