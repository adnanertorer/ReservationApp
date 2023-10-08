using Reservation.DataLayer;
using Reservation.Business;
using Reservation.Service;
using IsSystem.Application.Exceptions.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDataLayerServices(builder.Configuration);
builder.Services.AddBusinessServices();
builder.Services.AddReservationServices();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
   builder => builder.AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

 //if(app.Environment.IsProduction())
    app.UseCustomExceptionMiddleware();

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
