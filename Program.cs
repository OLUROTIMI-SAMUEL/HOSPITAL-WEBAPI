using WebAPIs.Hospital.CleanCrud.DAL;
using Microsoft.EntityFrameworkCore;
using WebAPIs.Hospital.CleanCrud.BLL;

var builder = WebApplication.CreateBuilder(args);



#region Default

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

#region Database
var CS = builder.Configuration.GetConnectionString("Hospital");
builder.Services.AddDbContext<HospitalContext>(options => options.UseSqlServer(CS));

#endregion



#region Repos
builder.Services.AddScoped<IDoctorsRepo, DoctorsRepo>();
builder.Services.AddScoped<IPatientsRepo, PatientsRepo>();
builder.Services.AddScoped<IDiseasesRepo, DiseasesRepo>();

#endregion

#region UOW
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
#endregion
#region Managers
builder.Services.AddScoped<IDoctorsManager, DoctorsManager>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
