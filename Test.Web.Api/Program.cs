using Microsoft.EntityFrameworkCore;
using Test.Data.Context;
using Test.Data.Repositories;
using Test.Data.Repositories.Interfaces;
using Test.Data.Services;
using Test.Data.Services.Interfaces;
using Test.Web.Api.Tools;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DbContextTest>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));

builder.Services.AddScoped<FilterModelValidation>();

builder.Services.AddScoped<IMapperService, MapperService>();

builder.Services.AddScoped(typeof(_IBaseRepository), typeof(_BaseRepository))
            .AddScoped(typeof(_IBaseService), typeof(_BaseService));

#region Base derived classes injection

var tempGeneralRepositories = typeof(_IBaseRepository).Assembly.GetTypes()
                   .Where(w => !w.Name.StartsWith("_") &&
                    w.Name.EndsWith("Repository"));

var repInterfaces = tempGeneralRepositories.Where(p => p.IsInterface);
var repImplementations = tempGeneralRepositories.Where(p => p.IsClass);

foreach (var repImplementation in repImplementations)
{
    var iterfaceName = string.Format("{0}{1}", "I", repImplementation.Name);
    var tempInterface = repInterfaces.FirstOrDefault(p => p.Name == iterfaceName);


    builder.Services.AddScoped(tempInterface, repImplementation);
}


var tempGeneralServices = typeof(_IBaseService).Assembly.GetTypes()
                   .Where(w => !w.Name.StartsWith("_") &&
                   w.Name.EndsWith("Service"));

var serInterfaces = tempGeneralServices.Where(p => p.IsInterface);
var serImplementations = tempGeneralServices.Where(p => p.IsClass);

foreach (var serImplementation in serImplementations)
{
    var iterfaceName = string.Format("{0}{1}", "I", serImplementation.Name);
    var tempInterface = serInterfaces.FirstOrDefault(p => p.Name == iterfaceName);


    builder.Services.AddScoped(tempInterface, serImplementation);
}

#endregion






builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddControllers().AddJsonOptions((JSOptions) =>
{
    JSOptions.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    JSOptions.JsonSerializerOptions.PropertyNamingPolicy = null;

});
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
app.UseCors("AllowFrontOrigin");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
