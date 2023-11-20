using Microsoft.EntityFrameworkCore;
using GrpcServiceDataBase.Services;
using GrpcServiceDataBase.Model;
using GrpcServiceDataBase.Model.Entities;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Xml;

//using (var dbcontext = new AppDataContext()) { 
//dbcontext.Database.Migrate();
//    dbcontext.UserAuthenticationInfo.Add(new UserAuthenticationInfo { Id = 1, Password = "12345", Phone = "89969520206"}) ;
//}

var builder = WebApplication.CreateBuilder(args);

//подключение к бд
builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<AppDataContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase")));


// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

//builder.Services.Configure<ConnectionStrings>(
//    builder.Configuration.GetSection(nameof(ConnectionStrings))
//);

// Configure the HTTP request pipeline.
//app.MapGrpcService<GreeterService>();

app.MapGrpcService<UserDoService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
