using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SmartCourseSystem.API.Data;
using SmartCourseSystem.API.Helpers;
using SmartCourseSystem.API.Mappings;
using SmartCourseSystem.API.Middleware;
using SmartCourseSystem.API.Repositories;
using SmartCourseSystem.API.Repositories.Interfaces;
using SmartCourseSystem.API.Services;
using SmartCourseSystem.API.Services.Interfaces;
using SmartCourseSystem.API.Validators;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(
    options =>
        options.UseNpgsql(
            builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy",
        policy =>
        {
            policy.AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowAnyOrigin();
        });
});
builder.Services.AddScoped<IAuthRepository,
    AuthRepository>();

builder.Services.AddScoped<IAuthService,
    AuthService>();

builder.Services.AddScoped<JwtHelper>();
builder.Services.AddScoped<
    ICategoryRepository,
    CategoryRepository>();

builder.Services.AddScoped<
    ICategoryService,
    CategoryService>();
builder.Services.AddScoped<
    ICourseRepository,
    CourseRepository>();

builder.Services.AddScoped<
    ICourseService,
    CourseService>();

builder.Services.AddScoped<
    ILessonRepository,
    LessonRepository>();

builder.Services.AddScoped<
    ILessonService,
    LessonService>();
builder.Services.AddScoped<
    IEnrollmentRepository,
    EnrollmentRepository>();

builder.Services.AddScoped<
    IEnrollmentService,
    EnrollmentService>();
builder.Services.AddScoped<
    IDashboardService,
    DashboardService>();

builder.Services
    .AddAuthentication(
        JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer =
                    builder.Configuration["Jwt:Issuer"],

                ValidAudience =
                    builder.Configuration["Jwt:Audience"],

                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            builder.Configuration["Jwt:Key"]!))
            };
    });
builder.Services.AddAutoMapper(
    typeof(MappingProfile));
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<
    IUserService,
    UserService>();
builder.Services
.AddValidatorsFromAssemblyContaining<
CreateCourseValidator>();

builder.Services.AddScoped<IRoleRepository, RoleRepository>();

builder.Services.AddScoped<IRoleService, RoleService>();


builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
   
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();


app.UseCors("ReactPolicy");
app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();

app.Run();
