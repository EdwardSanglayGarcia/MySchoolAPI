using API_Test.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using System.Text.Json.Serialization;
using System.Reflection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
    c.SwaggerDoc("v1",
        new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "School Management System API",
            Description = "This section contains the overall documentation of the School Management System of XYZ University",
            Version = "Final Version",
            License = new OpenApiLicense
            {
                Name = "Sample License",
                Url = new Uri("https://github.com/ESGFreelance")
            },
            Contact = new OpenApiContact
            {
                Name = "Edward Sanglay Garcia",
                Url = new Uri("https://github.com/ESGFreelance"),
                Email = "IAm@EdwardGarcia.tech"
            },
        });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
}
);
//Display enums as strings
builder.Services.AddControllers().AddJsonOptions(options =>
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddDbContext<MySchoolDBContext>(options => options.UseSqlServer
    (
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseSwaggerUI(options =>
    //{
    //    options.DefaultModelsExpandDepth(-1);
    //}); //Use this to remove the schema.
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
