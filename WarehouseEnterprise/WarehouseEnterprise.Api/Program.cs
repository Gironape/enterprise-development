using Microsoft.EntityFrameworkCore;
using WarehouseEnterprise.Api.Dto;
using WarehouseEnterprise.Api.Mapper;
using WarehouseEnterprise.Domain.Repositories;
using WarehouseEnterprise.Api.Services;
using WarehouseEnterprise.Domain.Context;
using WarehouseEnterprise.Domain;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        var clientAddresses = builder.Configuration.GetSection("ClientAddresses").Get<Dictionary<string, string>>();
        if (clientAddresses == null || !clientAddresses.Any())
        {
            throw new Exception("Секция 'ClientAddresses' не найдена или пуста в конфигурации appsettings.json.");
        }
        policy.WithOrigins(clientAddresses.Values.ToArray())
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});
builder.Services.AddEndpointsApiExplorer();
var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
builder.Services.AddSwaggerGen(c =>
{
    c.IncludeXmlComments(xmlPath);
});
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<WarehouseContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 39))));

builder.Services.AddScoped<IEntityRepository<Organization>, OrganizationRepository>();
builder.Services.AddScoped<IEntityRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IEntityRepository<Cell>, CellRepository>();
builder.Services.AddScoped<IEntityRepository<Supply>, SupplyRepository>();

builder.Services.AddScoped<IEntityService<OrganizationDto, OrganizationCreateDto>, OrganizationService>();
builder.Services.AddScoped<IEntityService<ProductDto, ProductCreateDto>, ProductService>();
builder.Services.AddScoped<IEntityService<CellDto, CellCreateDto>, CellService>();
builder.Services.AddScoped<IEntityService<SupplyDto, SupplyCreateDto>, SupplyService>();
builder.Services.AddScoped<IQueryService, QueryService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowReactApp");
app.MapControllers();
app.Run();