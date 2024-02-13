using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var config = builder.Configuration;

builder.Services.AddDbContext<GameViewLabContext>(opt =>
    opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IImageService, ImageService>();

builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowSpecificOrigin",
            builder =>
            {
                builder.WithOrigins(
                    "http://localhost:3000",
                    "https://22082476.github.io"
                )
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
    });




builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();