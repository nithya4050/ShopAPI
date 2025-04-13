using Microsoft.AspNetCore.Builder;
using ShopAPI.BusinessLogic;
using ShopAPI.DataAccess;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<SQLHelper>();
builder.Services.AddSingleton<UserLogic>();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "ShopAPI", Version = "v1" });
});


// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();

app.MapControllers();

app.Run();
