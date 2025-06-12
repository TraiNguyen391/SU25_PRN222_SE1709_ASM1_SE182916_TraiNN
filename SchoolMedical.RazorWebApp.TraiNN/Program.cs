using Microsoft.AspNetCore.Authentication.Cookies;
using SchoolMedical.RazorWebApp.TraiNN.Hubs;
using SchoolMedical.Service.TraiNN;
using SchoolMedical.RazorWebApp.TraiNN.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<IMedicationTraiNNService, MedicationTraiNNService>();
builder.Services.AddScoped<IMedicationOrderTraiNNService, MedicationOrderTraiNNService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.AccessDeniedPath = "/Account/Forbidden";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    });

//SignalR
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapRazorPages();

app.MapRazorPages().RequireAuthorization();

//SignalR
app.MapHub<SchoolMedicalHub>("/schoolMedicalHub");

app.Run();
