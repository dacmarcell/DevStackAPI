using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using portfolio_api.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? throw new InvalidOperationException("Connection string not found in configuration");

builder.Services.AddEndpointsApiExplorer().AddSwaggerGen(services => {
    services.SwaggerDoc("v1", new OpenApiInfo {Title = "PortfolioApi", Version = "v1"});
    services.ResolveConflictingActions(options => options.First());
});

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()){
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();