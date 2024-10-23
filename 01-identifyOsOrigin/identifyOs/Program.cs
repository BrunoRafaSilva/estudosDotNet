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
    var clientOs = new MyOsIdentify(httpContext);

    return clientOs;
})
.WithName("Client Os")
.WithOpenApi();

// https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.results.redirect?view=aspnetcore-8.0
app.MapGet("/redirecttoapp", (HttpContext httpContext) =>
{
    var clientOs = new MyOsIdentify(httpContext);

    return Results.Redirect(clientOs.StoreLink);
})
.WithName("Client Redirect")
.WithOpenApi();

await app.RunAsync();