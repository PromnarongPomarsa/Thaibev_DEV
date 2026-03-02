using BackEnd_Thaibev.Data;
using BackEnd_Thaibev.Repositories;
using BackEnd_Thaibev.Repositories.IRepositories;
using BackEnd_Thaibev.Repository;
using BackEnd_Thaibev.Repository.IRepository;
using BackEnd_Thaibev.Services;
using BackEnd_Thaibev.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

var MyAllowSpecificOrigins = "AllowAll";


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins, policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
// Add services to the container.
builder.Services.AddControllersWithViews();

// service
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IMasterService, MasterService>();
// repository
builder.Services.AddScoped<IMasterRepository, MasterRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

//// for railway
//using (var scope = app.Services.CreateScope())
//{
//    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//    db.Database.Migrate();
//}


app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
