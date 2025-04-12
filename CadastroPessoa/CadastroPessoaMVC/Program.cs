using Microsoft.EntityFrameworkCore;
using CadastroPessoaMVC.Data;
using CadastroPessoaMVC.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuração da conexão com o SQL Server
builder.Services.AddDbContext<CadastroContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<PessoaService>();


// Adiciona os controllers e as views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurações do pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pessoa}/{action=Index}/{id?}");

app.Run();
