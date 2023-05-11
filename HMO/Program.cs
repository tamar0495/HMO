using Microsoft.EntityFrameworkCore;
using Services;
using Entities.DBModels;
using Repository;

var builder = WebApplication.CreateBuilder(args);

string connectionString = "Data Source=DESKTOP-FVU1ABL;Initial Catalog=HMO;Integrated Security=True;TrustServerCertificate=True;";
// Add services to the container.

builder.Services.AddScoped<IMemberService,MemberService>();
builder.Services.AddScoped<IMemberRepository,MemberRepository>();
builder.Services.AddScoped<IVaccinationService,VaccinationService>();
builder.Services.AddScoped<IVaccinationRepository,VaccinationRepository>();
builder.Services.AddScoped<IVaccinationsDateService,VaccinationsDateService>();
builder.Services.AddScoped<IVaccinationDateRepository,VaccinationDateRepository>();

builder.Services.AddControllers();

builder.Services.AddDbContext<HmoContext>(options =>
options.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
