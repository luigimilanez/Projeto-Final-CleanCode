using clean_code_refactor;
using clean_code_refactor.Dal.Repositories.Base;
using clean_code_refactor.Domain.Bases;
using clean_code_refactor.Domain.Services.Base;
using clean_code_refactor.Domain.Services.Clientes.Validations;
using clean_code_refactor.Domain.Services.Reservas.Validations;
using clean_code_refactor.Domain.ViewModels;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Registros manuais de validações
builder.Services.AddScoped<IValidation<ClienteViewModel>, ClienteValidation>();
builder.Services.AddScoped<IValidation<ReservaViewModel>, ReservaValidation>();

// Registro genérico base
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));

builder.Services.AddInfraSql(builder.Configuration);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
