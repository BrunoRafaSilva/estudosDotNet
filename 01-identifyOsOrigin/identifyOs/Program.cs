using identifyOs.classes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/myos", (HttpContext httpContext) =>
{
    var clientOs = new MyOsClass(httpContext);

    return clientOs;
})
.WithName("Client Os")
.WithOpenApi();

await app.RunAsync();