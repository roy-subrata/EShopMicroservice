var builder = WebApplication.CreateBuilder(args);

//Register Services

//Handle Request
var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.Run();



