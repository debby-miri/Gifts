using AutoMapper;
using Solid.API;
using Solid.Core;
using Solid.Core.Repositories;
using Solid.Core.Services;
using Solid.Data;
using Solid.Data.Repository;
using Solid.Service;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(opt => opt.AddPolicy("PolicyName", policy =>
{
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();
/*builder.Services.AddSingleton<DataContext>();
*/builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IOpinionRepository,OpinionRepository>();
builder.Services.AddScoped<IGiftsRepository,GiftRepository>();
builder.Services.AddScoped<IGenderEventsCategryRepository,GenderEventsCategryRepository>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IOpinionService,OpinionService>();
builder.Services.AddScoped<IGiftService,GiftService>();
builder.Services.AddScoped<IGenderEventsCategryService,GenderEventsCategryService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddAutoMapper(typeof(MappingPro));
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("PolicyName");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
