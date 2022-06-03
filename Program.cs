using c_string_demo._2nd_attempt;
using c_string_demo.Models;
using c_string_demo.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MyBloggingContext>(options => options.UseSqlServer(connectionString: builder.Configuration.GetConnectionString("WritingConnection")));

builder.Services.AddDbContext<MyBackupBloggingContext>(options => options.UseSqlServer(connectionString: builder.Configuration.GetConnectionString("readConnection")));

//// Autofac
//var builder = new ContainerBuilder();

//// needed only if you plan to inject ICollection<BaseContext>
//builder.RegisterType<NavaContext>().As<BaseContext>();
//builder.RegisterType<StackContext>().As<BaseContext>();

//builder.Populate(services);

builder.Services.AddTransient<IStudentRepo, StudentRepo>();
builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
