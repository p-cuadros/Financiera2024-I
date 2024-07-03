using Financiera.Infra.Datos.EF;
using Microsoft.EntityFrameworkCore;
using Financiera.WebApp.Components;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FinancieraContexto>(
    opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("FinancieraBD"))
);
builder.Services.AddQuickGridEntityFrameworkAdapter();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
