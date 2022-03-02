using Serilog;
using ShoppingBL;
using ShoppingDL;

//Creating and configuring our logger
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./logs/user.txt") //We configure our logger to save in this file
    .CreateLogger();

var configuration = new ConfigurationBuilder() //Reading and obtaining connectionstring from .json file
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMemoryCache();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IRepository_c>(repo => new CustomerRepository(builder.Configuration.GetConnectionString("Reference2DBKey")));
builder.Services.AddScoped<ICustomerBL, CustomerBL>();

builder.Services.AddScoped<IRepository_o>(repo => new OrderRepository(builder.Configuration.GetConnectionString("Reference2DBKey")));
builder.Services.AddScoped<IOrderBL, OrderBL>();

builder.Services.AddScoped<IRepository_a>(repo => new AdminRepository(builder.Configuration.GetConnectionString("Reference2DBKey")));
builder.Services.AddScoped<IAdminBL, AdminBL>();

builder.Services.AddScoped<IRepository_s>(repo => new StoreRepository(builder.Configuration.GetConnectionString("Reference2DBKey")));
builder.Services.AddScoped<IStoreBL, StoreBL>();

builder.Services.AddScoped<IRepository_p>(repo => new ProductRepository(builder.Configuration.GetConnectionString("Reference2DBKey")));
builder.Services.AddScoped<IProductBL, ProductBL>();

builder.Services.AddScoped<IRepository_v>(repo => new InventoryRepository(builder.Configuration.GetConnectionString("Reference2DBKey")));
builder.Services.AddScoped<IInventoryBL, InventoryBL>();


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
