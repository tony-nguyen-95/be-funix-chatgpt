using Funix.HannahAssistant.Api;
using Funix.HannahAssistant.Api.IManagers;
using Funix.HannahAssistant.Api.IRepository;
using Funix.HannahAssistant.Api.Managers;
using Funix.HannahAssistant.Api.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var apiCorsPolicy = "ApiCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: apiCorsPolicy,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:3000")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                      });
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddAuthorization();
// Add services to the container.
//User MySQL
builder.Services.AddDbContext<HannahAssistantDbContext>(opt => {
    opt.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnectionString"));
});
//Use SQLServer
//builder.Services.AddDbContext<HannahAssistantDbContext>(opt =>
//{
//    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
//});
builder.Services.AddControllers().AddJsonOptions(
    x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
//Add Repository
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IHannahRepository, HannahRepository>();
builder.Services.AddScoped<IHannahStudentRepository, HannahStudentRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentContactRepository, StudentContactRepository>();
builder.Services.AddScoped<IStickyNoteRepository, StickyNoteRepository>();
builder.Services.AddScoped<ICertificateRepository, CertificateRepository>();
builder.Services.AddScoped<IStudentCertificateRepository, StudentCertificateRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICoursePlanningWeeklyScheduleRepository, CoursePlanningWeeklyScheduleRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<ILessionRepository, LessionRepository>();
//Temp Repository
builder.Services.AddScoped<ITempCertificateRepository, TempCertificateRepository>();
builder.Services.AddScoped<ITempCourseRepository, TempCourseRepository>();
builder.Services.AddScoped<ITempCertificateCourseRepository, TempCertificateCourseRepository>();
builder.Services.AddScoped<ITempSubjectRepository, TempSubjectRepository>();
builder.Services.AddScoped<ITempLessionRepository, TempLessionRepository>();
//Unit Of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//Add Managers
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IHannahManager, HannahManager>();
builder.Services.AddScoped<IStudentManager, StudentManager>();
builder.Services.AddScoped<IStickyNoteManager, StickyNoteManager>();
builder.Services.AddScoped<IDashboardManager, DashboardManager>();
builder.Services.AddScoped<ICertificateManager, CertificateManager>();
builder.Services.AddScoped<ITempDataManager, TempDataManager>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.UseCors(apiCorsPolicy);

app.UseAuthentication();

app.UseAuthorization();

app.UseHealthChecks("/healthy");

app.MapControllers();

app.Run();
