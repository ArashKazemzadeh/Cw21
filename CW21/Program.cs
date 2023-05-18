using System.Collections.ObjectModel;
using System.Data;
using CW21.DAL.Context;
using CW21.Repositories;
using CW21.Repositories.Doctors;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.MSSqlServer;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.Development.json", optional: false)
    .Build();
var columnOpts = new ColumnOptions()
{
    AdditionalColumns = new Collection<SqlColumn>()
    {
        new SqlColumn()
        {
            ColumnName="CrudState" , DataType=SqlDbType.NVarChar
        },
        new SqlColumn()
        {
            ColumnName="ProductId" , DataType=SqlDbType.Int
        }
    }
};
var sinkOpts = new MSSqlServerSinkOptions()
{
    AutoCreateSqlDatabase = true,
    AutoCreateSqlTable = true,
    TableName = "LogMaktab",
    SchemaName = "Base",
    BatchPeriod = TimeSpan.FromSeconds(10),
};
var FilePath = config.GetSection("LogConfig:FilePath").Value;
var SeqUrl = config.GetSection("LogConfig:SeqUrl").Value;
var DefaultConnection = config.GetSection("LogConfig:ConnectionString").Value;
Log.Logger = new LoggerConfiguration()
    .WriteTo.Logger(x =>
    {
        x.WriteTo.File(FilePath);
        x.MinimumLevel.Error();
        

    })
    .WriteTo.Logger(x=>
        x.WriteTo.Seq(SeqUrl))

            .WriteTo.Logger(x=>
        x.WriteTo.MSSqlServer(connectionString: DefaultConnection, sinkOptions: sinkOpts, columnOptions: columnOpts))
    
    .CreateLogger();


// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<AppDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


//app.MapAreaControllerRoute(
//    areaName: "DoctorArea",
//    name: "areas",
//    pattern: "{area:exists}/{controller=Account}/{action=LoginDoctor}/{id?}");



app.MapControllerRoute(
name: "default",
pattern: "{controller=Account}/{action=Index}/{id?}");




app.Run();

