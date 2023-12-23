using CountryVote.Interfaces;
using CountryVote.Services;
using CountryVoteDataBaseContext;
using CountryVoteRepositories.Implementation;
using CountryVoteRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddDbContext<CountryVoteDbContext>(options => options.UseInMemoryDatabase("CountryVoteDB"));
builder.Services.AddDbContext<CountryVoteDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));
builder.Services.AddScoped<IUserServices,UserServices>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<ICountryRepository,CountryRepository>();
builder.Services.AddScoped<ICountryService,CountryService>();
builder.Services.AddScoped<IAutheticatorService, AuthenticatorService>();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddHttpClient<IExternalApiService, ExternalApiService>(client =>
{
    client.BaseAddress = new Uri("https://restcountries.com/v3.1/");
   
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
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
