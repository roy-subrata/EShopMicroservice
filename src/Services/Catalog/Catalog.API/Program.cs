using Carter;
using Marten;

var builder = WebApplication.CreateBuilder(args);

//Register Services
builder.Services.AddMediatR(opt =>
{
    opt.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddMarten(opt =>
{
    var conn = builder.Configuration.GetConnectionString("Database")!;
    opt.Connection(conn);

}).UseLightweightSessions();


builder.Services.AddCarter();


//Handle Request
var app = builder.Build();
app.MapCarter();
app.Run();



